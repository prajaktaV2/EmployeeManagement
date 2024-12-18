﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Model.Models.PartnerApi;
using EmployeeManagement.Service.BusinessLogic.Interface;
using Newtonsoft.Json;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class PartnerApiService : IPartnerApiService
    {
        private readonly HttpClient _httpClient;

        public PartnerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductResponse>> GetPartnerProduct(int limit)
        {
            var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products?limit={limit}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products =JsonConvert.DeserializeObject<List<Products>>(content);
                var result = products?.Select(x => new ProductResponse
                {
                    Title = x.Title,
                    Price = x.Price,
                    Description = x.Description
                }).ToList();

                return result ?? new List<ProductResponse>();
            }
            else
            {
                Console.Error.WriteLine($"Error: {response.StatusCode}. Message: {response.ReasonPhrase}");
                return new List<ProductResponse>();
            }
            //var response = await _httpClient.GetFromJsonAsync<List<Products>>($"https://fakestoreapi.com/products?limit={limit}");
            //var result = response?.Select(x => new ProductResponse 
            //            { 
            //                Title=x.Title,
            //                Price=x.Price,
            //                Description= x.Description 
            //            }).ToList();
            //return result ?? [];
        }
    }
}
