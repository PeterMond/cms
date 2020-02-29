﻿using System;
using System.IO;

namespace SS.CMS.Core
{
	/// <summary>
	/// FileSystemInfoExtend
	/// </summary>
	public class FileSystemInfoExtend
	{

        private FileSystemInfo _file ;

		public FileSystemInfoExtend(FileSystemInfo file)
		{
			_file = file ;
		}
        public string Name => _file.Name;
        public string FullName => _file.FullName;

	    public bool IsDirectory => (_file.Attributes & FileAttributes.Directory)
	                               ==FileAttributes.Directory;

	    public string Type => IsDirectory ? "" : _file.Extension;
        public long Size
		{
			get
			{
				if ( IsDirectory )
					return 0L ;
				else
					return ((FileInfo)_file).Length  ;
			}
		}
        public DateTime LastWriteTime => _file.LastWriteTime;

	    public DateTime CreationTime => _file.CreationTime;
	}
}