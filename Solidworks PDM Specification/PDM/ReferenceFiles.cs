using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPDM.Interop.epdm;

namespace Solidworks_PDM_Specification
{
    internal class ReferenceFiles
    {
        public DrawingStamp stamp;
        private Settings settings;
        private string path;
        private List<Element> Elements;
        private IEdmVault5 vault;
        public ReferenceFiles(string path, Settings settings, DrawingStamp stamp, IEdmVault5 vault)
        {
            this.path = path;
            this.settings = settings;
            this.stamp = stamp;
            this.vault = vault;
        }

        public List<Element> GetListElements()
        {
            Elements = new List<Element>();
            List<RefFile> RefFiles = new List<RefFile>();
            GetReferencedFiles(null, path, 0 , "A", ref RefFiles);

            IEdmVault7 vault2 = null;
            vault2 = (IEdmVault7)vault;
            IEdmBatchListing4 BatchListing = default(IEdmBatchListing4);
            BatchListing = (IEdmBatchListing4)vault2.CreateUtility(EdmUtility.EdmUtil_BatchList);

            foreach (RefFile refFile in RefFiles)
            {
                ((IEdmBatchListing4)BatchListing).AddFileCfg(refFile.FilePath, DateTime.Now, (Convert.ToInt32(refFile.Level)), "@", Convert.ToInt32(EdmListFileFlags.EdmList_Nothing));
            }
            EdmListCol[] BatchListCols = null;
            ((IEdmBatchListing4)BatchListing).CreateListEx("\n\nDescription\nNumber", Convert.ToInt32(EdmCreateListExFlags.Edmclef_MayReadFiles), ref BatchListCols, null);
            EdmListFile2[] BatchListFiles = null;
            BatchListing.GetFiles2(ref BatchListFiles);
            foreach (EdmListFile2 BatchFile in BatchListFiles)
            {
                IEdmFile5 File = default(IEdmFile5);
                File = (IEdmFile5)vault.GetObject(EdmObjectType.EdmObject_File, BatchFile.mlFileID);
                Elements.Add(GetElementFromVault(File));
            }

            return Elements;
        }

        private void GetReferencedFiles(IEdmReference10 Reference, string FilePath, int Level, string ProjectName,
            ref List<RefFile> RefFiles)
        {
            try
            {
                if (Reference == null)
                {
                    IEdmFile5 File = null;
                    IEdmFolder5 ParentFolder = null;
                    RefFiles.Add(new RefFile(FilePath, Level.ToString()));
                    File = vault.GetFileFromPath(FilePath, out ParentFolder);
                    GetStamp(File);


                    Reference = (IEdmReference10) File.GetReferenceTree(ParentFolder.ID);
                    GetReferencedFiles(Reference, "", Level+1, ProjectName, ref RefFiles);
                }
                else
                {
                    IEdmPos5 pos = default(IEdmPos5);
                    IEdmReference10 Reference2 = (IEdmReference10) Reference;
                    pos = Reference2.GetFirstChildPosition3(ProjectName, true, true, (int) EdmRefFlags.EdmRef_File, "",
                        0);
                    IEdmReference10 @ref = default(IEdmReference10);

                    while ((!pos.IsNull))
                    {
                        @ref = (IEdmReference10) Reference.GetNextChild(pos);
                        RefFiles.Add(new RefFile(@ref.FoundPath, Level.ToString()));
                    }

                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetStamp(IEdmFile5 File)
        {
            IEdmEnumeratorVariable8 EnumVarObj = default(IEdmEnumeratorVariable8);
            EnumVarObj = (IEdmEnumeratorVariable8)File.GetEnumeratorVariable();
            object currentVar = null;
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Name"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Name = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Designation"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Designation = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["DrawingPaperSize"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.DrawingPaperSize = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Section"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Section = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Note"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Note = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Zone"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Zone = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Developer"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Developer = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Checker"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Checker = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["NormativeControl"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.NormativeControl = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Approver"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Approver = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Litera"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.Litera = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["InvNumbOrigin"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.InvNumbOrigin = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["ReplacedInvNumb"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.ReplacedInvNumb = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["InvNumbDupl"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.InvNumbDupl = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["ReferenceNumb"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.ReferenceNumb = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["PrimaryApplication"], "По умолчанию", out currentVar);
            if (currentVar != null)
                stamp.PrimaryApplication = currentVar.ToString();
            EnumVarObj.CloseFile(false);
        }

        private Element GetElementFromVault(IEdmFile5 File)
        {
            Element element = new Element();
            IEdmEnumeratorVariable8 EnumVarObj = default(IEdmEnumeratorVariable8);
            EnumVarObj = (IEdmEnumeratorVariable8)File.GetEnumeratorVariable();
            object currentVar = null;
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Name"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.Name = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Designation"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.Designation = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["DrawingPaperSize"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.DrawingPaperSize = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Section"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.Section = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Note"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.Note = currentVar.ToString();
            EnumVarObj.GetVar(settings.ComparsionGlobalVariable["Zone"], "По умолчанию", out currentVar);
            if (currentVar != null)
                element.Zone = currentVar.ToString();
            EnumVarObj.CloseFile(false);
            element.FilePath = path;
            return element;
        }

    }
}
