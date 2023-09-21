using System.Numerics;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.DTOs.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public string? Message{ get; set; }
        public bool IsSuccess{ get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int StatusCode { get; set; }
    }
}
