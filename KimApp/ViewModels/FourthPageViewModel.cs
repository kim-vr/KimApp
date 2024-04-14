namespace KimApp.ViewModels;

public class FourthPageViewModel
{
    public ChessTimerViewModel ChessTimer { get; }
    public MealPlannerViewModel MealPlanner { get; }

    public FourthPageViewModel()
    {
        ChessTimer = new ChessTimerViewModel();
        MealPlanner = new MealPlannerViewModel();
    }

}