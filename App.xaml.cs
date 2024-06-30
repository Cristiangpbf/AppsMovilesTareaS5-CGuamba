using cGuambaS5.Utils;

namespace cGuambaS5
{
    public partial class App : Application
    {
        public static PersonRepository personRepository { get; set; }
        public App(PersonRepository person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personRepository = person;
        }
    }
}
