using System;
using System.Data;
using System.Xml;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// <author>Rizwan Ansari</author>
	/// <date>19-06-2007</date>
	/// </summary>
	public class XmlUtil
	{
		private string m_path;
		private string m_nodeText;
		private XmlDocument xmlDoc; 

		public XmlUtil()
		{
			
		}
		public void Save()
		{
			xmlDoc.Save(Path);

		}

		public XmlUtil(string p_path)
		{
			
			xmlDoc = new XmlDocument(); 
			xmlDoc.Load(p_path);
			Path = p_path;
		}

		public string Path
		{
			get
			{
				return m_path;
			}
			set 
			{
				m_path = value;
			}
			
		}

		public string GetNode(string p_nodeName)
		{
			XmlNode node;
			XmlNode lastNode;

			if(p_nodeName.Equals(""))
			{
				m_nodeText = "Node name missing";
				return m_nodeText;
			}
			
			m_nodeText = "";
			if(xmlDoc.HasChildNodes)
			{
				node = xmlDoc.DocumentElement;
				if(!node.HasChildNodes)
				{
					return m_nodeText;
				}
				else
				{
					node = xmlDoc.DocumentElement.FirstChild;
					
					if(node.Name == p_nodeName)
					{
						m_nodeText = node.InnerText;
					}
					else
					{
						lastNode = xmlDoc.DocumentElement.LastChild;
						do
						{
							if(node == lastNode && node.Name != p_nodeName)
							{
								m_nodeText = "";
								return m_nodeText;
							}
							node = node.NextSibling;
							
						}while(node.Name != p_nodeName);
						m_nodeText = node.InnerText;
					}

				}
				return m_nodeText;
			}
			else 
			{
				return m_nodeText = "Invalid XML Document";
			}
			
		}

		public void SetNode(string p_nodeName, string p_nodeText)
		{
			XmlNode node;
			XmlNode lastNode;

			if((p_nodeName.Equals("") && p_nodeText.Equals(""))|| p_nodeName.Equals(""))
			{
				return;
			}
			/*else
			{
				p_nodeText = "";
			}*/

			if(xmlDoc.HasChildNodes)
			{
				node = xmlDoc.DocumentElement;
				if(!node.HasChildNodes)
				{
					CreateNode(p_nodeName,p_nodeText);
					return;
				}
				else
				{
					node = xmlDoc.DocumentElement.FirstChild;
					if(node.Name == p_nodeName)
					{
						node.InnerText = "";
						node.InnerText = p_nodeText;
						return;
					}
					else
					{
						lastNode = xmlDoc.DocumentElement.LastChild;
						do
						{
							if(node == lastNode && node.Name != p_nodeName)
							{
								CreateNode(p_nodeName, p_nodeText);
								return;
							}
							node = node.NextSibling;
							
						}while(node.Name != p_nodeName);
						if(node.Name == p_nodeName)
						{
							node.InnerText = "";
							node.InnerText = p_nodeText;
							return;
						}
					}
				}
			}
			else 
			{
				CreateNode(p_nodeName,p_nodeText);
				return;
			}
      
		}

		public void CreateNode(string p_nodeName, string p_nodeText)
		{
			XmlElement newElem;
			XmlNode newNode;

			if(xmlDoc.HasChildNodes)
			{
				newElem = xmlDoc.CreateElement(p_nodeName);
				newElem.InnerText = p_nodeText;
				newNode = xmlDoc.DocumentElement;
				newNode.AppendChild(newElem);
				xmlDoc.Save(this.Path+"AppSettings.xml");
				
			}
			else
			{
				newElem = xmlDoc.CreateElement(p_nodeName);
				newElem.InnerText = p_nodeText;
				newNode = xmlDoc.AppendChild(newElem);
				xmlDoc.Save(this.Path+ "AppSettings.xml");
			}
			return;
		}

		public void CloseDocument()
		{
			if(xmlDoc != null)
			{
				xmlDoc = null;
			}
		}
	}
}
