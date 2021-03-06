﻿/* Copyright (c) Citrix Systems Inc. 
 * All rights reserved. 
 * 
 * Redistribution and use in source and binary forms, 
 * with or without modification, are permitted provided 
 * that the following conditions are met: 
 * 
 * *   Redistributions of source code must retain the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer. 
 * *   Redistributions in binary form must reproduce the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer in the documentation and/or other 
 *     materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR 
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 */

using System;
using XenAdmin.Core;
using XenAdmin.Dialogs;

namespace XenAdmin.TabPages
{
    public class GeneralTabLicenseStatusStringifier
    {
        public ILicenseStatus Status { private get; set; }

        public GeneralTabLicenseStatusStringifier(ILicenseStatus status) 
        {
            Status = status;
        }

        public string ExpiryDate
        {
            get
            {
                if (Status.LicenseExpiresIn.TotalDays < 3653)
                    return HelpersGUI.DateTimeToString(Status.LicencedHost.LicenseExpiryUTC.ToLocalTime(),
                                                        Messages.DATEFORMAT_DMY_LONG, true);

                return Messages.LICENSE_NEVER;
            }
        }

        public string ExpiryStatus
        {
            get
            {
                if (Status == null || !Status.Updated)
                    return Messages.GENERAL_UNKNOWN;

                if (Status.ExpiryDate.HasValue)
                {
                    if (Status.CurrentState == LicenseStatus.HostState.Unavailable)
                        return Messages.LICENSE_EXPIRED_NO_LICENSES_AVAILABLE;

                    if (Status.CurrentState == LicenseStatus.HostState.Expired)
                    {
                        if (Status.LicencedHost.IsFreeLicense() && !Status.IsUsingPerSocketGenerationLicenses)
                            return Messages.LICENSE_REQUIRES_ACTIVATION;
                        
                        return Status.IsUsingPerSocketGenerationLicenses ? Messages.LICENSE_UNSUPPORTED : Messages.LICENSE_EXPIRED;
                    }

                    TimeSpan s = Status.LicenseExpiresExactlyIn;
                    if (Status.LicencedHost.IsFreeLicense())
                    {
                        
                        if (s.TotalMinutes < 2)
                            return String.Format(Messages.LICENSE_REQUIRES_ACTIVATION_ONE_MIN, s.Minutes);

                        if (s.TotalHours < 2)
                            return String.Format(Messages.LICENSE_REQUIRES_ACTIVATION_MINUTES, s.Minutes);

                        if (s.TotalDays < 2)
                            return String.Format(Messages.LICENSE_REQUIRES_ACTIVATION_HOURS, s.Hours);

                        if (s.TotalDays < 30)
                            return String.Format(Messages.LICENSE_REQUIRES_ACTIVATION_DAYS, s.Days);

                        return Messages.LICENSE_ACTIVATED;
                    }

                    if (s.TotalMinutes < 2)
                        return String.Format(Messages.LICENSE_EXPIRES_ONE_MIN, s.Minutes);

                    if (s.TotalHours < 2)
                        return String.Format(Messages.LICENSE_EXPIRES_MINUTES, s.Minutes);

                    if (s.TotalDays < 2)
                        return String.Format(Messages.LICENSE_EXPIRES_HOURS, s.Hours);

                    if (s.TotalDays < 30)
                        return String.Format(Messages.LICENSE_EXPIRES_DAYS, s.Days);

                    return Messages.LICENSE_LICENSED;
                }
                return Messages.GENERAL_UNKNOWN;
            }
        }

    }
}
