using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.api.ws.Models
{
    public class ResponseModel
    {
        public object Data { get; set; }
        public ErrorModel Error { get; set; }

        public ResponseModel()
        {
            this.Error = new ErrorModel();
        }
    }

    public class ChecksumResponseModel
    {
        public string Checksum { get; set; }
        public object Data { get; set; }
        public ErrorModel Error { get; set; }

        public ChecksumResponseModel()
        {
            this.Error = new ErrorModel();
        }
    }

    public class PageResponseModel<T>
    {
        public int Count { get; set; }
        public T[] Results { get; set; }

        public PageResponseModel()
        {
        }

        public PageResponseModel(int Totals, T[] Rows)
        {
            this.Count = Totals;
            this.Results = Rows;
        }
    }

    public class ErrorModel
    {
        public string Message { get; set; }
        public string Suggestion { get; set; }
    }
}
