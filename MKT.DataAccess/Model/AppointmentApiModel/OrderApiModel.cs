using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MKT.DataAccess.Model.AppointmentApiModel
{
    // OrderApiModel myDeserializedClass = JsonSerializer.Deserialize<OrderApiModel>(myJsonResponse);
    public class OrderApiModel
    {
        [JsonPropertyName("order")]
        public Order Order { get; set; }
    }

}