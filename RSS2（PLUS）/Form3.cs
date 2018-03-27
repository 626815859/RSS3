using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSS阅读器2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            XmlReader xml = XmlReader.Create("../book.xml");
            JiaZai(xml);
        }
        private void JiaZai(XmlReader reader)
        {
            XmlValidatingReader Valid = new XmlValidatingReader(reader);
            Valid.ValidationType = ValidationType.None;
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode rssNode = FoundChildNode(doc, "rss");
            XmlNode channelNode = FoundChildNode(rssNode, "channel");
            Rss.Channel channel = new Rss.Channel();
            channel.Item = new Hashtable();
            for (int i = 0; i < channelNode.ChildNodes.Count; i++)
            {
                switch (channelNode.ChildNodes[i].Name)
                {
                    case "title":
                        {
                            channel.title = channelNode.ChildNodes[i].InnerText;

                            break;
                        }
                    case "item":
                        {
                            Rss.Item item = this.getRssItem(channelNode.ChildNodes[i]);
                            channel.Item.Add(channel.Item.Count, item);

                            break;
                        }
                }
            }
            ViewRss(channel);

        }
        private XmlNode FoundChildNode(XmlNode Node, string Name)
        {
            XmlNode childlNode = null;
            for (int i = 0; i < Node.ChildNodes.Count; i++)
            {
                if (Node.ChildNodes[i].Name == Name && Node.ChildNodes[i].ChildNodes.Count > 0)
                {
                    childlNode = Node.ChildNodes[i];
                    return childlNode;
                }
            }
            return childlNode;
        }
        private Rss.Item getRssItem(XmlNode Node)
        {
            Rss.Item item = new Rss.Item();
            for (int i = 0; i < Node.ChildNodes.Count; i++)
            {
                if (Node.ChildNodes[i].Name == "title")
                {
                    item.title = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "description")
                {
                    item.description = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "link")
                {
                    item.link = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "author")
                {
                    item.author = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "pubdate")
                {
                    item.pubdate = Node.ChildNodes[i].InnerText;
                }

            }
            return item;
        }
        private void ViewRss(Rss.Channel channel)
        {
            treeRss.BeginUpdate();
            treeRss.Nodes.Clear();
            TreeNode channelNode = treeRss.Nodes.Add(channel.title);
            channelNode.Tag = "";
            for (int i = 0; i<channel.Item.Count; i++)
            {
                Rss.Item item = (Rss.Item)channel.Item[i];

                TreeNode itemNode = channelNode.Nodes.Add(item.title);
                TreeNode tree = itemNode.Nodes.Add(item.link);
                itemNode.Tag = item.link;
            }
            treeRss.ExpandAll();
            treeRss.EndUpdate();
        }
        private void treeRss_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            web.Text = e.Node.Text;
            webBrowser1.Navigate(web.Text);
        }
       
    }
}
