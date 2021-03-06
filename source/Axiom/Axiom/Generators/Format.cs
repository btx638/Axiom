﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2020 Matt McManis
https://github.com/MattMcManis/Axiom
https://axiomui.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */

/* ----------------------------------
 METHODS

 * Force Format
 * Cut Controls
 * Cut Start
 * Cut End
---------------------------------- */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Disable XML Comment warnings
#pragma warning disable 1591
#pragma warning disable 1587
#pragma warning disable 1570

namespace Axiom
{
    public class Format
    {
        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Global Variables
        /// </summary>
        /// --------------------------------------------------------------------------------------------------------
        // Cut
        public static string trimStart { get; set; }
        public static string trimEnd { get; set; }
        //public static string trim; // combine trimStart, trimEnd

        // --------------------------------------------------
        // File Formats
        // --------------------------------------------------

        // -------------------------
        // Video
        // -------------------------
        public static List<string> VideoFormats = new List<string>()
        {
            ".3g2",
            ".3gp",
            ".amv",
            ".asf",
            ".avi",
            ".drc",
            ".flv",
            ".f4v",
            ".f4p",
            ".f4a",
            ".f4b",
            ".gif",
            ".gifv",
            ".mkv",
            ".mng",
            ".mov",
            ".mp4",
            ".m4p",
            ".m2v",
            ".m4v",
            ".mpg",
            ".mp2",
            ".mpeg",
            ".mpe",
            ".mpv",
            ".mpg",
            ".mxf",
            ".nsv",
            ".ogv",
            ".ogg",
            ".rm",
            ".rmvb",
            ".roq",
            ".svi",
            ".vob",
            ".qt",
            ".webm",
            ".wmv",
            ".x264",
            ".x265",
            ".yuv"
        };

        // Video Entry Type Stream
        public static List<string> VideoFormats_EntryType_Stream = new List<string>()
        {
            ".3g2",
            ".3gp",
            ".flv",
            ".m4v",
            ".mov",
            ".mp4",
            ".ogv",
            ".qt",
            ".swf",
            ".webm",
            ".wmv",
        };

        // Video Entry Type Format
        public static List<string> VideoFormats_EntryType_Format = new List<string>()
        {
            ".asf",
            ".avi",
            ".mkv",
            ".mod",
            ".mpeg",
            ".mpg",
            ".vob",
        };

        // -------------------------
        // Audio
        // -------------------------
        public static List<string> AudioFormats = new List<string>()
        {
            ".aa",
            ".aac",
            ".aax",
            ".act",
            ".aiff",
            ".amr",
            ".ape",
            ".au",
            ".awb",
            ".dct",
            ".dss",
            ".dvf",
            ".flac",
            ".gsm",
            ".iklax",
            ".ivs",
            ".m4a",
            ".m4b",
            ".m4p",
            ".mmf",
            ".mp3",
            ".mpc",
            ".msv",
            ".ogg",
            ".oga",
            ".opus",
            ".ra",
            ".rm",
            ".raw",
            ".sln",
            ".tta",
            ".vox",
            ".wav",
            ".wma",
            ".wv",
            ".8svx"
        };



        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Methods
        /// </summary>
        /// --------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Force Format
        /// </summary>
        // Used for Two-Pass, Pass 1
        public static String ForceFormat(string container_SelectedItem)
        {
            string format = string.Empty;

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            switch (container_SelectedItem)
            {
                // -------------------------
                // webm
                // -------------------------
                case "webm":
                    format = "-f webm";
                    break;

                // -------------------------
                // mp4
                // -------------------------
                case "mp4":
                    format = "-f mp4";
                    break;

                // -------------------------
                // mkv
                // -------------------------
                case "mkv":
                    format = "-f matroska";
                    break;

                // -------------------------
                // m2v
                // -------------------------
                case "m2v":
                    format = "-f mpeg2video";
                    break;

                // -------------------------
                // mpg
                // -------------------------
                case "mpg":
                    format = "-f mpeg";
                    break;

                // -------------------------
                // avi
                // -------------------------
                case "avi":
                    format = "-f avi";
                    break;

                // -------------------------
                // ogv
                // -------------------------
                case "ogv":
                    format = "-f ogv";
                    break;

                // --------------------------------------------------
                // Image
                // --------------------------------------------------
                // -------------------------
                // jpg
                // -------------------------
                case "jpg":
                    // do not use
                    break;

                // -------------------------
                // png
                // -------------------------
                case "png":
                    // do not use
                    break;

                // -------------------------
                // webp
                // -------------------------
                case "webp":
                    format = "-f webp";
                    break;

                // --------------------------------------------------
                // Audio
                // --------------------------------------------------
                // -------------------------
                // mp3
                // -------------------------
                case "mp3":
                    format = "-f mp3";
                    break;

                // -------------------------
                // m4a
                // -------------------------
                case "m4a":
                    format = string.Empty;
                    break;

                // -------------------------
                // ogg
                // -------------------------
                case "ogg":
                    format = "-f ogg";
                    break;

                // -------------------------
                // flac
                // -------------------------
                case "flac":
                    format = "-f flac";
                    break;

                // -------------------------
                // wav
                // -------------------------
                case "wav":
                    format = "-f wav";
                    break;
            }

            return format;
        }


        /// <summary>
        /// Cut Start
        /// </summary>
        public static String CutStart(string input_Text,
                                      bool batch_IsChecked,
                                      string cut_SelectedItem,
                                      string cutStart_Text_Hours,
                                      string cutStart_Text_Minutes,
                                      string cutStart_Text_Seconds,
                                      string cutStart_Text_Milliseconds,
                                      string frameStart_Text
            )
        {
            // -------------------------
            // Yes
            // -------------------------
            if (cut_SelectedItem == "Yes")
            {
                // -------------------------
                // Time
                // -------------------------
                // If Frame Textboxes Default Use Time
                if (string.IsNullOrEmpty(frameStart_Text))
                {
                    // Start
                    trimStart = cutStart_Text_Hours.PadLeft(2, '0') + ":" +
                                cutStart_Text_Minutes.PadLeft(2, '0') + ":" +
                                cutStart_Text_Seconds.PadLeft(2, '0') + "." +
                                cutStart_Text_Milliseconds.PadLeft(3, '0');
                }

                // -------------------------
                // Frames
                // -------------------------
                // If Frame Textboxes have Text, but not Default, 
                // use FramesToDecimal Method (Override Time)
                else if (!string.IsNullOrEmpty(frameStart_Text))
                {
                    trimStart = Video.FramesToDecimal(frameStart_Text);
                }


                trimStart = "-ss " + trimStart;
            }

            // -------------------------
            // No
            // -------------------------
            else if (cut_SelectedItem == "No")
            {
                trimStart = string.Empty;
            }

            // Return Value
            return trimStart;
        }


        /// <summary>
        /// Cut End
        /// </summary>
        public static String CutEnd(string input_Text,
                                    bool batch_IsChecked,
                                    string mediaType_SelectedItem,
                                    string cut_SelectedItem,
                                    string cutEnd_Text_Hours,
                                    string cutEnd_Text_Minutes,
                                    string cutEnd_Text_Seconds,
                                    string cutEnd_Text_Milliseconds,
                                    string frameEnd_Text
            )
        {
            // -------------------------
            // Yes
            // -------------------------
            if (cut_SelectedItem == "Yes")
            {
                // Video, Image Sequence, Audio
                // Image only has Start, no End
                if (mediaType_SelectedItem != "Image")
                {
                    // -------------------------
                    // Time
                    // -------------------------
                    // If Frame Textboxes Default Use Time
                    if (string.IsNullOrEmpty(frameEnd_Text))
                    {
                        // End
                        trimEnd = cutEnd_Text_Hours.PadLeft(2, '0') + ":" +
                                  cutEnd_Text_Minutes.PadLeft(2, '0') + ":" +
                                  cutEnd_Text_Seconds.PadLeft(2, '0') + "." +
                                  cutEnd_Text_Milliseconds.PadLeft(3, '0');

                        // If End Time is Empty, Default to Full Duration
                        // Input Null Check
                        if (!string.IsNullOrEmpty(input_Text))
                        {
                            if (trimEnd == "00:00:00.000" ||
                                string.IsNullOrEmpty(trimEnd))
                            {
                                trimEnd = FFprobe.CutDuration(input_Text, batch_IsChecked);
                            }
                        }

                    }

                    // -------------------------
                    // Frames
                    // -------------------------
                    // If Frame Textboxes have Text, but not Default, 
                    // use FramesToDecimal Method (Override Time)
                    else if (!string.IsNullOrEmpty(frameEnd_Text))
                    {
                        trimEnd = Video.FramesToDecimal(frameEnd_Text);
                    }


                    trimEnd = "-to " + trimEnd;
                }
            }

            // -------------------------
            // No
            // -------------------------
            else if (cut_SelectedItem == "No")
            {
                trimEnd = string.Empty;
            }

            // Return Value
            return trimEnd;
        }


    }
}
