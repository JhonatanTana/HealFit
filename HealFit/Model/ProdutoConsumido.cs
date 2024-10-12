namespace HealFit.Model;
public class ProdutoConsumido {

    public int ConsumoId { get; set; }
    public string Produto { get; set; }
    public string ServingId { get; set; }
    public string ServingDescription { get; set; }
    public string MetricServingAmount { get; set; }
    public string MetricServingUnit { get; set; }
    public string NumberOfUnits { get; set; }
    public string MeasurementDescription { get; set; }
    public string? Calories { get; set; }
    public string? Carbohydrate { get; set; }
    public string? Protein { get; set; }
    public string? Fat { get; set; }
    public string? SaturatedFat { get; set; }
    public string? PolyunsaturatedFat { get; set; }
    public string? MonounsaturatedFat { get; set; }
    public string? Cholesterol { get; set; }
    public string? Sodium { get; set; }
    public string? Potassium { get; set; }
    public string? Fiber { get; set; }
    public string? Sugar { get; set; }
    public string? VitaminA { get; set; }
    public string? VitaminC { get; set; }
    public string? Calcium { get; set; }
    public string? Iron { get; set; }
    public string? TransFat { get; set; }
    public string? AddedSugars { get; set; }
    public string? VitaminD { get; set; }
    public DateTime Data { get; set; }
    public int UsuarioId { get; set; }
}
