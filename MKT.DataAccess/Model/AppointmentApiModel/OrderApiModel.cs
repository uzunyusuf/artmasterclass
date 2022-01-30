using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MKT.DataAccess.Model.AppointmentApiModel
{
    // OrderApiModel myDeserializedClass = JsonSerializer.Deserialize<OrderApiModel>(myJsonResponse);

    public partial class OrderApiModel
    {
        [JsonPropertyName("order")]
        public Order Order { get; set; }
    }

}