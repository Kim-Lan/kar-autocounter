using System.Drawing;
using System.Xml;
using LiveSplit.UI;

namespace LiveSplit.UI.Components
{
    public class ItemTracker
    {
        public ItemTracker(string itemName = "", int initialValue = 0, int goalValue = 0, Image icon = null)
        {
            Name = itemName;
            Initial = initialValue;
            Count = initialValue;
            Goal = goalValue;
            Icon = icon;
        }

        public string Name { get; private set; }
        public int Initial { get; private set; }
        public int Count { get; private set; }
        public int Goal { get; private set; }
        public Image Icon { get; private set; }


        public void Reset()
        {
            Count = Initial;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetInitial(int initialValue)
        {
            Initial = initialValue;
        }

        public void SetCount(int value)
        {
            Count = value;
        }

        public void SetGoal(int goalValue)
        {
            Goal = goalValue;
        }

        public void SetIcon(Image icon)
        {
            Icon = icon;
        }

        public static ItemTracker FromXml(XmlNode node)
        {
            var element = (XmlElement)node;
            return new ItemTracker(SettingsHelper.ParseString(element["ItemName"]),
                SettingsHelper.ParseInt(element["Initial"]),
                SettingsHelper.ParseInt(element["Goal"]),
                SettingsHelper.GetImageFromElement(element["Icon"]));
        }

        public int CreateElement(XmlDocument document, XmlElement element)
        {
            return SettingsHelper.CreateSetting(document, element, "ItemName", Name) ^
                SettingsHelper.CreateSetting(document, element, "Initial", Initial) ^
                SettingsHelper.CreateSetting(document, element, "Goal", Goal) ^
                SettingsHelper.CreateSetting(document, element, "Icon", Icon);
        }
    }
}
