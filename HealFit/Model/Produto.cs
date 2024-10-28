using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Model; 
public class Produtos {

    public int ConsumoId { get; set; }
    public string Produto { get; set; }
    public string ServingId { get; set; }
    public string ServingDescription { get; set; }
    public string MetricServingAmount { get; set; }
    public string MetricServingUnit { get; set; }
    public string NumberOfUnits { get; set; }
    public string MeasurementDescription { get; set; }
    public double Calories { get; set; }
    public double Carbohydrate { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double SaturatedFat { get; set; }
    public double PolyunsaturatedFat { get; set; }
    public double MonounsaturatedFat { get; set; }
    public double Cholesterol { get; set; }
    public double Sodium { get; set; }
    public double Potassium { get; set; }
    public double Fiber { get; set; }
    public double Sugar { get; set; }
    public double VitaminA { get; set; }
    public double VitaminC { get; set; }
    public double Calcium { get; set; }
    public double Iron { get; set; }
    public double TransFat { get; set; }
    public double AddedSugars { get; set; }
    public double VitaminD { get; set; }
    public DateTime Data { get; set; }
    public int UsuarioId { get; set; }
    public double Quantidade { get; set; }
}
