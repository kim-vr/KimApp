namespace KimApp.ViewModels;

using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

public class MealPlannerViewModel : BindableObject
{
    public ObservableCollection<MealPlan> Meals { get; set; }

    public MealPlannerViewModel()
    {
        Meals = new ObservableCollection<MealPlan>();
        Meals.Add(new MealPlan { Day = "Monday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Tuesday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Wednesday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Thursday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Friday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Saturday", Meal = "" });
        Meals.Add(new MealPlan { Day = "Sunday", Meal = "" });
    }
    
}

public class MealPlan
{
    public string Day { get; set; }
    public string Meal { get; set; }
}