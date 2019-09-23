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
        Game f = new Game(menuForm.difficulty.SelectedText);
        f.Show();
    }
}
