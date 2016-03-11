namespace Chess
{
    using System;
    using System.Windows.Forms;
    
    using Models;
    using UI;
    
    public static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var statistic = new Statistic();
            var userTemplateCreator = new UserTemplateCreator();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGameManager(userTemplateCreator, statistic));
        }
    }
}