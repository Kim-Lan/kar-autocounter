using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.Options;
using System.Linq;

namespace LiveSplit.UI.Components
{
    public partial class AutoCounterComponentSettings : UserControl
    {
        private const int ICONINDEX = 0;
        private const int NAMEINDEX = 1;
        private const int INITIALINDEX = 2;
        private const int GOALINDEX = 3;

        public BindingList<ItemTracker> ItemList { get; set; }

        public List<Image> ImagesToDispose { get; set; }

        public int OldPersonalBest { get; set; }
        public int CurrentPersonalBest { get; set; }
        public string OldPersonalBest_Label { get; set; }
        public string CurrentPersonalBest_Label { get; set; }
        public TextComponent OldPersonalBest_Component { get; set; }
        public TextComponent CurrentPersonalBest_Component { get; set; }

        public int Total { get { return ItemList[ItemList.Count - 1].Count; } }

        public Font NameFont { get; set; }
        public Font CountFont { get; set; }
        public Font GoalFont { get; set; }
        public string NameFontString => SettingsHelper.FormatFont(NameFont);
        public string CountFontString => SettingsHelper.FormatFont(CountFont);
        public string GoalFontString => SettingsHelper.FormatFont(GoalFont);

        public Color BackgroundColor { get; set; }
        public Color GoalColor { get; set; }

        public bool DisplayIcons { get; set; }
        public bool ShowGoal { get; set; }
        public bool OverrideFont { get; set; }
        public float IconSize { get; set; }

        public event EventHandler SettingsChanged;

        public LayoutMode Mode { get; set; }

        public LiveSplitState CurrentState { get; set; }

        public AutoCounterComponentSettings(LiveSplitState state)
        {
            InitializeComponent();
            CurrentState = state;
            ImagesToDispose = new List<Image>();
            ItemList = new BindingList<ItemTracker>();
            ItemList.AllowNew = true;
            ItemList.AllowRemove = true;
            ItemList.AllowEdit = true;
            ItemList.Add(new ItemTracker());

            itemGrid.AutoGenerateColumns = false;
            itemGrid.AutoSize = true;
            itemGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            itemGrid.DataSource = ItemList;
            itemGrid.CellDoubleClick += itemGrid_CellDoubleClick;
            itemGrid.CellFormatting += itemGrid_CellFormatting;
            itemGrid.CellParsing += itemGrid_CellParsing;
            itemGrid.CellValidating += itemGrid_CellValidating;
            itemGrid.CellEndEdit += itemGrid_CellEndEdit;

            DisplayIcons = true;
            ShowGoal = true;
            OverrideFont = false;
            IconSize = 24f;
            BackgroundColor = Color.Transparent;
            GoalColor = Color.FromArgb(51, 115, 244);
            NameFont = new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
            CountFont = new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);
            GoalFont = new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Pixel);

            OldPersonalBest = 0;
            CurrentPersonalBest = 0;

            txt_oldPersonalBest.DataBindings.Add("Text", this, "OldPersonalBest_Label", false, DataSourceUpdateMode.OnPropertyChanged);
            txt_currentPersonalBest.DataBindings.Add("Text", this, "CurrentPersonalBest_Label", false, DataSourceUpdateMode.OnPropertyChanged);

            chk_displayIcons.DataBindings.Add("Checked", this, "DisplayIcons", false, DataSourceUpdateMode.OnPropertyChanged);
            chk_showGoal.DataBindings.Add("Checked", this, "ShowGoal", false, DataSourceUpdateMode.OnPropertyChanged);
            chk_font.DataBindings.Add("Checked", this, "OverrideFont", false, DataSourceUpdateMode.OnPropertyChanged);
            trk_iconSize.DataBindings.Add("Value", this, "IconSize", false, DataSourceUpdateMode.OnPropertyChanged);
            btn_bgColor.DataBindings.Add("BackColor", this, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            btn_goalColor.DataBindings.Add("BackColor", this, "GoalColor", false, DataSourceUpdateMode.OnPropertyChanged);
            font_name.DataBindings.Add("Text", this, "NameFontString", false, DataSourceUpdateMode.OnPropertyChanged);
            font_count.DataBindings.Add("Text", this, "CountFontString", false, DataSourceUpdateMode.OnPropertyChanged);
            font_goal.DataBindings.Add("Text", this, "GoalFontString", false, DataSourceUpdateMode.OnPropertyChanged);

            chk_displayIcons.CheckedChanged += chk_displayIcons_CheckedChanged;
            chk_showGoal.CheckedChanged += chk_showGoal_CheckedChanged;
            chk_font.CheckedChanged += chk_font_CheckedChanged;

            Load += AutoCounterSettings_Load;

            Model.Input.EventHandlerT<TimerPhase> ResetEventHandler = (s, e) => { UpdatePersonalBest(); };
            state.OnReset += ResetEventHandler;
        }

        private void AutoCounterSettings_Load(object sender, EventArgs e)
        {
            chk_displayIcons_CheckedChanged(null, null);
            chk_showGoal_CheckedChanged(null, null);
            chk_font_CheckedChanged(null, null);
            SetTextComponents();
        }

        private void SetTextComponents()
        {
            foreach (dynamic component in CurrentState.Layout.Components)
            {
                string name = component.ComponentName;
                if (!String.IsNullOrWhiteSpace(OldPersonalBest_Label) && name.StartsWith(OldPersonalBest_Label))
                    OldPersonalBest_Component = (TextComponent)component;
                else if (!String.IsNullOrWhiteSpace(CurrentPersonalBest_Label) && name.StartsWith(CurrentPersonalBest_Label))
                    CurrentPersonalBest_Component = (TextComponent)component;
            }
        }

        public void SetCount(string name, int count)
        {
            foreach (ItemTracker item in ItemList)
            {
                if (item.Name == name)
                    item.SetCount(count);
            }
        }

        public void UpdatePersonalBest()
        {
            if (Total > CurrentPersonalBest)
                CurrentPersonalBest = Total;
            if (CurrentPersonalBest > OldPersonalBest)
                OldPersonalBest = CurrentPersonalBest;
            if (OldPersonalBest_Component != null)
                OldPersonalBest_Component.Settings.Text2 = OldPersonalBest.ToString();
            if (CurrentPersonalBest_Component != null)
                CurrentPersonalBest_Component.Settings.Text2 = CurrentPersonalBest.ToString();
        }

        public void ResetCurrentPersonalBest()
        {
            CurrentPersonalBest = 0;

            if (CurrentPersonalBest_Component != null)
                CurrentPersonalBest_Component.Settings.Text2 = "0";
        }

        private void RaiseSettingsChanged()
        {
            SettingsChanged?.Invoke(this, null);
        }

        void itemGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            itemGrid.Rows[e.RowIndex].ErrorText = "";
        }

        void itemGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == INITIALINDEX || e.ColumnIndex == GOALINDEX)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                    return;

                try
                {
                    IsValidInteger(e.FormattedValue.ToString(), 0, Int32.MaxValue);
                }
                catch
                {
                    e.Cancel = true;
                    itemGrid.Rows[e.RowIndex].ErrorText = "Invalid Integer";
                }
            }
        }

        void itemGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var parsingResults = ParseCell(e.Value, e.RowIndex, e.ColumnIndex, true);
            if (parsingResults.Parsed)
            {
                e.ParsingApplied = true;
                e.Value = parsingResults.Value;
            }
            else
                e.ParsingApplied = false;
        }

        private ParsingResults ParseCell(object value, int rowIndex, int columnIndex, bool shouldFix)
        {
            if (columnIndex == NAMEINDEX)
            {
                ItemList[rowIndex].SetName(value.ToString());
                return new ParsingResults(true, value);
            }

            try
            {
                value = Int32.Parse(value.ToString());

                if (columnIndex == INITIALINDEX)
                {
                    ItemList[rowIndex].SetInitial((int)value);
                    ItemList[rowIndex].Reset();
                }

                if (columnIndex == GOALINDEX)
                    ItemList[rowIndex].SetGoal((int)value);

                return new ParsingResults(true, value);
            }

            catch { }

            return new ParsingResults(false, null);
        }

        void itemGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < ItemList.Count)
            {
                ItemTracker item = ItemList[e.RowIndex];

                if (e.ColumnIndex == NAMEINDEX)
                {
                    e.Value = item.Name;
                }
                else if (e.ColumnIndex == ICONINDEX)
                {
                    e.Value = item.Icon;
                }
                else if (e.ColumnIndex == INITIALINDEX)
                {
                    e.Value = item.Initial;
                }
                else if (e.ColumnIndex == GOALINDEX)
                {
                    e.Value = item.Goal;
                }
            }
        }

        void itemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ICONINDEX && e.RowIndex >= 0 && e.RowIndex < ItemList.Count)
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG|All files (*.*)|*.*";
                var multiEdit = itemGrid.SelectedCells.Count > 1;
                if (!string.IsNullOrEmpty(ItemList[e.RowIndex].Name) && !multiEdit)
                {
                    dialog.Title = "Set Icon for " + ItemList[e.RowIndex].Name + "...";
                }
                else
                {
                    dialog.Title = "Set Icon...";
                }
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ChangeImage(e.RowIndex, dialog.FileName, multiEdit);
                }
            }
        }

        private void ChangeImage(int rowIndex, string fileName, bool multiEdit)
        {
            try
            {
                var image = Image.FromFile(fileName);

                if (!multiEdit)
                {
                    var oldImage = (Image)itemGrid.Rows[rowIndex].Cells[ICONINDEX].Value;
                    if (oldImage != null)
                        ImagesToDispose.Add(oldImage);

                    ItemList[rowIndex].SetIcon(image);
                    itemGrid.NotifyCurrentCellDirty(true);
                }
                else
                {
                    foreach (DataGridViewCell cell in itemGrid.SelectedCells)
                    {
                        if (cell.ColumnIndex != ICONINDEX)
                            continue;

                        var oldImage = (Image)cell.Value;
                        if (oldImage != null)
                            ImagesToDispose.Add(oldImage);

                        ItemList[cell.RowIndex].SetIcon((Image)image.Clone());
                        itemGrid.UpdateCellValue(ICONINDEX, cell.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("Could not load image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            var newItem = new ItemTracker();
            ItemList.Add(newItem);
            itemGrid.ClearSelection();
            itemGrid.CurrentCell = itemGrid.Rows[ItemList.Count - 1].Cells[0];
            itemGrid.CurrentCell.Selected = true;
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            foreach (var selectedObject in itemGrid.SelectedCells)
            {
                var selectedCell = (DataGridViewCell)selectedObject;
                var selectedIndex = selectedCell.RowIndex;

                if (ItemList.Count <= 1 || selectedIndex >= ItemList.Count || selectedIndex < 0)
                    continue;
                if (selectedIndex == ItemList.Count - 1 && selectedIndex == itemGrid.CurrentRow.Index)
                {
                    itemGrid.ClearSelection();
                    itemGrid.CurrentCell = itemGrid.Rows[itemGrid.CurrentRow.Index - 1].Cells[itemGrid.CurrentCell.ColumnIndex];
                    itemGrid.CurrentCell.Selected = true;
                }
                if (ItemList[selectedIndex].Icon != null)
                    ImagesToDispose.Add(ItemList[selectedIndex].Icon);
                ItemList.RemoveAt(selectedIndex);
            }
        }

        void chk_displayIcons_CheckedChanged(object sender, EventArgs e)
        {
            trk_iconSize.Enabled = lbl_iconSize.Enabled = chk_displayIcons.Checked;
        }

        void chk_showGoal_CheckedChanged(object sender, EventArgs e)
        {
            lbl_goalFont.Enabled = btn_chooseGoalFont.Enabled = font_goal.Enabled = chk_showGoal.Checked;
        }

        void chk_font_CheckedChanged(object sender, EventArgs e)
        {
            grp_font.Enabled = chk_font.Checked;
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            DisplayIcons = SettingsHelper.ParseBool(element["DisplayIcons"]);
            ShowGoal = SettingsHelper.ParseBool(element["ShowGoal"]);
            OverrideFont = SettingsHelper.ParseBool(element["OverrideFont"]);
            NameFont = SettingsHelper.GetFontFromElement(element["NameFont"]);
            CountFont = SettingsHelper.GetFontFromElement(element["CountFont"]);
            GoalFont = SettingsHelper.GetFontFromElement(element["GoalFont"]);
            BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"], Color.Transparent);
            GoalColor = SettingsHelper.ParseColor(element["GoalColor"], Color.FromArgb(51, 115, 244));
            IconSize = SettingsHelper.ParseFloat(element["IconSize"], 24f);
            OldPersonalBest_Label = SettingsHelper.ParseString(element["OldPersonalBest_Label"]);
            CurrentPersonalBest_Label = SettingsHelper.ParseString(element["CurrentPersonalBest_Label"]);
            OldPersonalBest = SettingsHelper.ParseInt(element["PersonalBest"]);

            var itemsElement = element["ItemList"];
            ItemList.Clear();
            foreach (var child in itemsElement.ChildNodes)
            {
                ItemList.Add(ItemTracker.FromXml((XmlNode)child));
            }
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            var hashCode = SettingsHelper.CreateSetting(document, parent, "Version", "0.1") ^
                SettingsHelper.CreateSetting(document, parent, "DisplayIcons", DisplayIcons) ^
                SettingsHelper.CreateSetting(document, parent, "ShowGoal", ShowGoal) ^
                SettingsHelper.CreateSetting(document, parent, "OverrideFont", OverrideFont) ^
                SettingsHelper.CreateSetting(document, parent, "IconSize", IconSize) ^
                SettingsHelper.CreateSetting(document, parent, "NameFont", NameFont) ^
                SettingsHelper.CreateSetting(document, parent, "CountFont", CountFont) ^
                SettingsHelper.CreateSetting(document, parent, "GoalFont", GoalFont) ^
                SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
                SettingsHelper.CreateSetting(document, parent, "GoalColor", GoalColor) ^
                SettingsHelper.CreateSetting(document, parent, "OldPersonalBest_Label", OldPersonalBest_Label) ^
                SettingsHelper.CreateSetting(document, parent, "CurrentPersonalBest_Label", CurrentPersonalBest_Label);

            hashCode ^= SettingsHelper.CreateSetting(document, parent, "PersonalBest", OldPersonalBest);

            XmlElement itemsElement = null;
            if (document != null)
            {
                itemsElement = document.CreateElement("ItemList");
                parent.AppendChild(itemsElement);
            }

            foreach (var itemData in ItemList)
            {
                XmlElement item = null;
                if (document != null)
                {
                    item = document.CreateElement("Item");
                    itemsElement.AppendChild(item);
                }
                hashCode ^= itemData.CreateElement(document, item);
            }

            return hashCode;
        }

        private class ParsingResults
        {
            public bool Parsed { get; set; }
            public object Value { get; set; }

            public ParsingResults(bool parsed, object value)
            {
                Parsed = parsed;
                Value = value;
            }
        }

        private void btn_chooseNameFont_Click(object sender, EventArgs e)
        {
            var dialog = SettingsHelper.GetFontDialog(NameFont, 8, 100);
            dialog.FontChanged += (s, ev) => NameFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
            dialog.ShowDialog(this);
            font_name.Text = NameFontString;
        }

        private void btn_chooseCountFont_Click(object sender, EventArgs e)
        {
            var dialog = SettingsHelper.GetFontDialog(CountFont, 8, 100);
            dialog.FontChanged += (s, ev) => CountFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
            dialog.ShowDialog(this);
            font_count.Text = CountFontString;
        }

        private void btn_chooseGoalFont_Click(object sender, EventArgs e)
        {
            var dialog = SettingsHelper.GetFontDialog(GoalFont, 8, 100);
            dialog.FontChanged += (s, ev) => GoalFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
            dialog.ShowDialog(this);
            font_goal.Text = GoalFontString;
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            List<DataGridViewCell> selectedCells = itemGrid.SelectedCells.Cast<DataGridViewCell>().OrderBy(o => o.RowIndex).ToList();

            var selectedIndex = selectedCells.First().RowIndex;
            bool currCell = false;

            if (selectedCells != null)
            {
                foreach (DataGridViewCell selectedCell in selectedCells)
                {
                    selectedIndex = selectedCell.RowIndex;
                    if (selectedIndex > 0)
                    {
                        SwapItems(selectedIndex - 1, selectedIndex);

                        if (!currCell)
                        {
                            itemGrid.CurrentCell = itemGrid.Rows[selectedIndex - 1].Cells[itemGrid.CurrentCell.ColumnIndex];
                            currCell = true;
                        }

                        itemGrid.Rows[selectedIndex - 1].Cells[itemGrid.CurrentCell.ColumnIndex].Selected = true;
                    }
                }
            }
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            List<DataGridViewCell> selectedCells = itemGrid.SelectedCells.Cast<DataGridViewCell>().OrderBy(o => o.RowIndex).ToList();

            var selectedIndex = selectedCells.First().RowIndex;
            bool currCell = false;

            if (selectedCells != null)
            {
                foreach (DataGridViewCell selectedCell in selectedCells)
                {
                    selectedIndex = selectedCell.RowIndex;
                    if (selectedIndex < ItemList.Count - 1)
                    {
                        SwapItems(selectedIndex, selectedIndex + 1);

                        if (!currCell)
                        {
                            itemGrid.CurrentCell = itemGrid.Rows[selectedIndex + 1].Cells[itemGrid.CurrentCell.ColumnIndex];
                            currCell = true;
                        }

                        itemGrid.Rows[selectedIndex + 1].Cells[itemGrid.CurrentCell.ColumnIndex].Selected = true;
                    }
                }
            }
        }
        
        private void ColorButtonClick(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick((Button)sender, this);
        }

        public static bool IsValidInteger(string value, int min = int.MinValue, int max = int.MaxValue)
        {
            int x = 0;
            return int.TryParse(value, out x) && IsInRange(x, min, max);
        }

        public static bool IsInRange(int x, int min, int max)
        {
            return ((x >= min) && (x <= max));
        }

        private void SwapItems(int firstIndex, int secondIndex)
        {
            if (secondIndex < firstIndex)
            {
                int temp = firstIndex;
                firstIndex = secondIndex;
                secondIndex = temp;
            }

            var firstItem = ItemList.ElementAt(firstIndex);
            var secondItem = ItemList.ElementAt(secondIndex);

            ItemList.Remove(secondItem);
            ItemList.Insert(firstIndex, secondItem);
            ItemList.Remove(firstItem);
            ItemList.Insert(secondIndex, firstItem);
        }

        private void txt_oldPersonalBest_TextChanged(object sender, EventArgs e)
        {
            OldPersonalBest_Component = null;
            SetTextComponents();
        }

        private void txt_currentPersonalBest_TextChanged(object sender, EventArgs e)
        {
            CurrentPersonalBest_Component = null;
            SetTextComponents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OldPersonalBest = 0;
            if (OldPersonalBest_Component != null)
                OldPersonalBest_Component.Settings.Text2 = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetCurrentPersonalBest();
        }

        private void chk_displayIcons_CheckStateChanged(object sender, EventArgs e)
        {
            RaiseSettingsChanged();
        }

        private void chk_showGoal_CheckStateChanged(object sender, EventArgs e)
        {
            RaiseSettingsChanged();
        }
    }
}
