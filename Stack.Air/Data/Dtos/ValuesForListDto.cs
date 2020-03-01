using System;
namespace com.b_velop.Stack.Air.Data.Dtos
{
    public class ValuesForListDto
    {
        public long Id { get; set; }
        public string Time { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double SdsP1 { get; set; }
        public double SdsP2 { get; set; }
    }
}
