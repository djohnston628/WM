using System;
using System.Collections.Generic;

namespace WMAssess_DavidJ.Models
{
	public class BusinessResponse
	{
        private object? _data;

        public bool Success { get; set; }
        public string? Message { get; set; }

        public T GetData<T>()
        {
            if (_data is T typedData)
            {
                return typedData;
            }
            else
            {
                throw new InvalidOperationException($"Data is not of type {typeof(T)}");
            }
        }

        public void SetData<T>(T value)
        {
            _data = value;
        }
    }
}




