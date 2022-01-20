namespace MKT.WebUI.Models.Home
{
    public class HomeIndexViewModel
    {
        public int TotalAssignedWorkshop { get; set; }
        public int TotalLocation { get; set; }
        public int FutureWorkshopCount { get; set; }
        public int PreviousWorkshopCount { get; set; }

        public double AssignedWorkshopPriceTotal { get; set; }
    }
}