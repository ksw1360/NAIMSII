using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DevExpress.Xpf.Docking;
using DevExpress.XtraEditors.Filtering;
using NAIMS2.Common.Interfaces;

namespace NAIMS2.Common.UI
{
    public class DockManager: DockLayoutManager
    {
        public string? LayoutKey { get; set; }
        public string? LayoutFileName { get; set; }
        public DockManager()
        {
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (LayoutFileName != null)
            {
                string? layoutKey2 = null;

                try
                {
                    var xdoc = XDocument.Load(this.LayoutFileName);
                    var root = xdoc.Root;
                    var attr = root.Attribute("LayoutKey");
                    if(attr != null) layoutKey2 = attr.Value;
                }
                catch { }

                if (this.LayoutKey == layoutKey2) {
                    try
                    {
                        this.RestoreLayoutFromXml(this.LayoutFileName);
                    }
                    catch { }
                }
            }

        }

        protected override void OnDispose()
        {
            if (LayoutFileName != null)
            {

                try
                {
                    this.SaveLayoutToXml(this.LayoutFileName);

                }
                catch { }

                try
                {
                    var xdoc = XDocument.Load(this.LayoutFileName);
                    var root = xdoc.Root;
                    root.SetAttributeValue("LayoutKey", this.LayoutKey);
                    xdoc.Save(this.LayoutFileName);
                }
                catch { }
            }

            base.OnDispose();
        }
    }
}
