using cGuambaS5.Modelos;

namespace cGuambaS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personRepository.AddNewPerson(txtNombre.Text);
        status.Text = App.personRepository.StatusMessage;
        RefreshList();
    }

    private void btnlistar_Clicked(object sender, EventArgs e)
    {
        RefreshList();
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var person = button?.CommandParameter as Persona;
        App.personRepository.UpdatePerson(person);
        status.Text = App.personRepository.StatusMessage;
        RefreshList();        
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var person = button?.CommandParameter as Persona;
        App.personRepository.DeletePerson(person);
        status.Text = App.personRepository.StatusMessage;
        RefreshList();        
    }

    private void RefreshList()
    {
        List<Persona> people = App.personRepository.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }
}