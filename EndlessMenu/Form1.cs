namespace EndlessMenu
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem toolStripMenuItem;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();

            toolStripMenuItem = new ToolStripMenuItem((count++).ToString());
            toolStripMenuItem.DropDownOpening += DropDownOpeningHandler;

            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Items.Add(toolStripMenuItem);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
        }

        void DropDownOpeningHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem parent = sender as ToolStripMenuItem;

            if (!parent.HasDropDownItems)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem((count++).ToString());
                newItem.DropDownOpening += DropDownOpeningHandler;
                parent.DropDownItems.Add(newItem);
            }
        }
    }
}
