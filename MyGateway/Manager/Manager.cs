using System;
using System.Collections.Generic;
using MyGateway.Manager.FulfillmentServices.BSL.CommunicationLog;
using MyGateway.Models;
using MyGateway.Repository;
using Newtonsoft.Json;

namespace MyGateway.Controllers
{
    internal class Manager
    {
        public Manager()
        {
        }

        public string GetResultList(RequestData requestData, DateTime requestDateTime)
        {
            string jsonData = string.Empty;
            string jsonRequestData = string.Empty;
            DateTime requestStart = DateTime.Now;

            try
            {
                jsonRequestData = JsonConvert.SerializeObject(requestData);

                List<ResultDTO> resultsDTO = new List<ResultDTO>();
                using (ResultsRepository questionnaireRepository = new ResultsRepository()) //dependency in repositiry
                {
                    resultsDTO = questionnaireRepository.GetAvailableQuestionnaires(requestData.orgNumber, requestData.baseName, requestData.isCreditCardItem);
                }

                List<Result> resultList = new List<Result>();
                foreach (ResultDTO question in resultsDTO)
                {
                    Result result = new Result();
                    result.MasterQuestionnaireID = question.MasterQuestionnaireID;
                    result.description = question.Description;
                    result.updatedDate = question.UpdatedDate.ToString();
                    result.updatedByUserName = question.UpdatedByUserName;
                    result.baseForms = question.BaseForms;
                    result.CreditCards = null; //initialize as null, will add value later if .isCreditCardItem is true
                    result.CreditCardGroups = null; //initialize as null, will add value later if .isCreditCardItem is true
                    if (requestData.isCreditCardItem)
                    {
                        //add the new fields to the QuestionnaireData object and assign them here.
                        result.CreditCards = question.CreditCards; //JsonConvert.SerializeObject(question.CreditCards).Replace("/","");
                        result.CreditCardGroups = question.CreditCardGroups; //JsonConvert.SerializeObject(question.CreditCardGroups).Replace("/", "");
                        result.CreditCardParsingPassed = question.CreditCardParsingPassed;
                        result.CreditCardValidationError = question.CreditCardValidationError;
                    }

                    resultList.Add(result);
                }

                jsonData = JsonConvert.SerializeObject(resultList);

            }
            catch (Exception ex)
            {
                Logger.LogCustomError(ex.ToString(), LogInformation.LogFilePath);
                jsonData = "Exception occured. Kindly contact IT Support.";

            }
            finally
            {
                LogCommunication(jsonRequestData, requestStart, jsonData); 
            }
            return jsonData;
        }

        public void LogCommunication(string jsonRequestData, DateTime requestStart, string jsonData)
        {

            LogDTO logDTO = new LogDTO();
            logDTO.AppName = "LFOGateWay";
            logDTO.CreatedByUserID = Environment.UserName;
            logDTO.HTTPStatusCode = null;
            logDTO.IsOutbound = false;
            //logDTO.NetSuiteEnvironmentID
            logDTO.OutboundEndpointURL = null;
            logDTO.OutboundMethodCalled = null;
            logDTO.RequestBody = jsonRequestData;
            logDTO.RequestedResource = "GetQuestionnaire";
            logDTO.RequestEndTime = DateTime.Now;
            logDTO.RequestHeaders = null;
            logDTO.RequestStartTime = requestStart;
            logDTO.DurationOfCall = logDTO.RequestEndTime.Subtract(logDTO.RequestStartTime).Milliseconds;
            logDTO.RequestType = 1;//1 for web request
            logDTO.Response = jsonData;
            logDTO.ServerName = Environment.MachineName;
            //Create New Log Object
            LogBSL.InsertLog(logDTO); //dependency on LogBSL
        }
    }
}