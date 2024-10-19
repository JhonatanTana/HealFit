namespace HealFit.Model;
public class Serving {
    public long serving_id { get; set; }
    public string serving_description { get; set; }
    public string serving_url { get; set; }
    public string metric_serving_amount { get; set; }
    public string metric_serving_unit { get; set; }
    public decimal number_of_units { get; set; }
    public string measurement_description { get; set; }
    public decimal? Calories { get; set; }
    public decimal? Carbohydrate { get; set; }
    public decimal? Protein { get; set; }
    public decimal? Fat { get; set; }
    public decimal? saturated_fat { get; set; }
    public decimal? polyunsaturated_fat { get; set; }
    public decimal? monounsaturated_fat { get; set; }
    public decimal? Cholesterol { get; set; }
    public decimal? Sodium { get; set; }
    public decimal? Potassium { get; set; }
    public decimal? Fiber { get; set; }
    public decimal? Sugar { get; set; }
    public decimal? vitamin_d { get; set; }
    public decimal? vitamin_a { get; set; }
    public decimal? vitamin_c { get; set; }
    public decimal? Calcium { get; set; }
    public decimal? Iron { get; set; }
    public int? is_default { get; set; }
    public decimal? trans_fat { get; set; }
    public decimal? added_sugars { get; set; }
}
