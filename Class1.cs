using System;
using System.Runtime.InteropServices;

namespace testProgramCsharp
{
    internal static class FolderPicker
    {
        private const uint FOS_PICKFOLDERS = 0x00000020;
        private const uint SIGDN_FILESYSPATH = 0x80058000;

        public static string PickFolder(string title)
        {
            var dialog = (IFileOpenDialog)new FileOpenDialog();

            dialog.GetOptions(out uint options);
            dialog.SetOptions(options | FOS_PICKFOLDERS);

            dialog.SetTitle(title);

            int result = dialog.Show(IntPtr.Zero);

            // User pressed Cancel
            if (result != 0)
                return null;

            dialog.GetResult(out IShellItem item);

            item.GetDisplayName(
                SIGDN_FILESYSPATH,
                out IntPtr pathPtr);

            string path = Marshal.PtrToStringUni(pathPtr);

            Marshal.FreeCoTaskMem(pathPtr);
            Marshal.ReleaseComObject(item);
            Marshal.ReleaseComObject(dialog);

            return path;
        }

        [ComImport]
        [Guid("DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7")]
        private class FileOpenDialog
        {
        }

        [ComImport]
        [Guid("D57C7288-D4AD-4768-BE02-9D969532D960")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFileOpenDialog
        {
            [PreserveSig]
            int Show(IntPtr parent);

            [PreserveSig]
            int SetFileTypes(uint count, IntPtr filters);

            [PreserveSig]
            int SetFileTypeIndex(uint index);

            [PreserveSig]
            int GetFileTypeIndex(out uint index);

            [PreserveSig]
            int Advise(IntPtr events, out uint cookie);

            [PreserveSig]
            int Unadvise(uint cookie);

            [PreserveSig]
            int SetOptions(uint options);

            [PreserveSig]
            int GetOptions(out uint options);

            [PreserveSig]
            int SetDefaultFolder(IShellItem folder);

            [PreserveSig]
            int SetFolder(IShellItem folder);

            [PreserveSig]
            int GetFolder(out IShellItem folder);

            [PreserveSig]
            int GetCurrentSelection(out IShellItem item);

            [PreserveSig]
            int SetFileName(
                [MarshalAs(UnmanagedType.LPWStr)] string name);

            [PreserveSig]
            int GetFileName(
                [MarshalAs(UnmanagedType.LPWStr)] out string name);

            [PreserveSig]
            int SetTitle(
                [MarshalAs(UnmanagedType.LPWStr)] string title);

            [PreserveSig]
            int SetOkButtonLabel(
                [MarshalAs(UnmanagedType.LPWStr)] string text);

            [PreserveSig]
            int SetFileNameLabel(
                [MarshalAs(UnmanagedType.LPWStr)] string text);

            [PreserveSig]
            int GetResult(out IShellItem item);

            [PreserveSig]
            int AddPlace(
                IShellItem place,
                uint alignment);

            [PreserveSig]
            int SetDefaultExtension(
                [MarshalAs(UnmanagedType.LPWStr)] string extension);

            [PreserveSig]
            int Close(int hr);

            [PreserveSig]
            int SetClientGuid(ref Guid guid);

            [PreserveSig]
            int ClearClientData();

            [PreserveSig]
            int SetFilter(IntPtr filter);

            [PreserveSig]
            int GetResults(out IntPtr results);

            [PreserveSig]
            int GetSelectedItems(out IntPtr items);
        }

        [ComImport]
        [Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem
        {
            [PreserveSig]
            int BindToHandler(
                IntPtr bindContext,
                ref Guid handlerId,
                ref Guid interfaceId,
                out IntPtr result);

            [PreserveSig]
            int GetParent(out IShellItem parent);

            [PreserveSig]
            int GetDisplayName(
                uint nameType,
                out IntPtr name);

            [PreserveSig]
            int GetAttributes(
                uint attributes,
                out uint result);

            [PreserveSig]
            int Compare(
                IShellItem item,
                uint hint,
                out int order);
        }
    }
}
