namespace KimApp.ViewModels;

using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

public class MealPlannerViewModel : BindableObject
{
    public ObservableCollection<MealPlan> Meals { get; }

    public MealPlannerViewModel()
    {
        Meals = new ObservableCollection<MealPlan>();
        // Example data
        Meals.Add(new MealPlan { Day = "Monday", Meal = "Chicken Salad", Strategy = "Balanced Diet" });
    }

    public Command AddMealCommand => new Command(() => Meals.Add(new MealPlan { Day = "Tuesday", Meal = "Beef Stew", Strategy = "High Protein" }));
}

public class MealPlan
{
    public string Day { get; set; }
    public string Meal { get; set; }
    public string Strategy { get; set; }
}
