﻿using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace RedArrow.Jsorm.Sample
{
	public class IntegrationTestFixture : IDisposable
	{
		public string AccessToken { get; }

		public IntegrationTestFixture()
		{
			using (var authClient = new HttpClient {BaseAddress = new Uri("http://titan-test.centralus.cloudapp.azure.com/api/")})
			{

				var reqBody = new StringContent(JsonConvert.SerializeObject(new
				{
					accountId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
					applicationId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
					email = "ral.titan.shared@gmail.com",
					password = "Password$$11"
				}), Encoding.UTF8, "application/json");
				var response = authClient.PostAsync("auth/login", reqBody).GetAwaiter().GetResult();

				response.EnsureSuccessStatusCode();

				var responseContentStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				dynamic resContent = JsonConvert.DeserializeObject(responseContentStr);
				AccessToken = resContent.token;
			}
		}

		public void Dispose()
		{
		}
	}
}
