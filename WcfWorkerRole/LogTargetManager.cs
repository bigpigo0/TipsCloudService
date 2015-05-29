﻿using System.IO;
using NLog;
using NLog.Targets;

namespace WcfWorkerRole
{
    public static class LogTargetManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void SetLogTargetBaseDirectory(string targetName, string baseDirectory)
        {
            logger.Debug("SetLogTargetBaseDirectory() - Log Target Name: {0}.", targetName);
            logger.Debug("SetLogTargetBaseDirectory() - (New) Base Directory: {0}.", baseDirectory);

            var logTarget = (FileTarget)LogManager.Configuration.FindTargetByName(targetName);

            if (logTarget != null)
            {
                // Capture the Target's current Filename and Archive Filename
                var currentTargetFilename = Path.GetFileName(logTarget.FileName.ToString().TrimEnd('\''));
                //var currentTargetArchiveFilename = Path.GetFileName(logTarget.ArchiveFileName.ToString().TrimEnd('\''));

                // Re-base the Target's Filename and Archive Filename Directory to that supplied in 'baseDirectory'.
                logTarget.FileName = Path.Combine(baseDirectory, currentTargetFilename);
                //logTarget.ArchiveFileName = Path.Combine(baseDirectory, currentTargetArchiveFilename);

                logger.Debug("Logger Target '{0}' Filename re-based to: {1}", targetName, logTarget.FileName);
                //logger.Debug("Logger Target '{0}' Archive Filename re-based to: {1}", targetName, logTarget.ArchiveFileName);
            }

            // Re-configure the existing logger with the new logging target details
            LogManager.ReconfigExistingLoggers();
        }
    }
}