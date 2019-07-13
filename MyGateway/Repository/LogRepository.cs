using System;
using MyGateway.Models;

namespace MyGateway.Repository
{
    public class LogRepository : IDisposable
    {
        public void Insert(LogDTO logDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void InsertForSpecificNetSuiteEnvironmentID(LogDTO logDto, int specificNetSuiteEnvironmentId)
        {
            throw new NotImplementedException();
        }
    }
}