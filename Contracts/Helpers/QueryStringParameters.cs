﻿namespace Contracts.Helpers
{
    public class QueryStringParameters
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; } = true;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}