namespace HealFit.Model;
public class Food {
    public string food_description { get; set; }
    public int food_id { get; set; }
    public string food_name { get; set; }
    public string food_type { get; set; }
    public string food_url { get; set; }
    public string brand_name { get; set; }
    public Servings servings { get; set; }
    public string? TranslatedFoodName { get; set; } // Nova propriedade para armazenar o nome traduzido

}
