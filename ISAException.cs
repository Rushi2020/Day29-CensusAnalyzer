using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day29_CensusAnalyzer
{
    internal class ISAException : Exception 
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            FILE_TYPE_INCORRECT,
            Wrong_DELIMITER, 
            Wrong_HEADER
        }
        public ExceptionType Type;

        public ISAException(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }
    }
}
