using System;
using Minesweeper;

public class MenuHandler
{

    Menu menuForm;

	public MenuHandler(Menu form)
	{
        menuForm = form;
        form.difficulty.SelectedIndex = 0;
	}

    public void RunGame()
    {
        Game f = new Game(menuForm.difficulty.SelectedIndex, Convert.ToInt32(menuForm.widthField.Value), Convert.ToInt32(menuForm.heightField.Value), Convert.ToInt32(menuForm.bombsField.Value));
        f.Closed += (s, args) => menuForm.Close();
        f.Show();
        menuForm.Hide();
    }
}
