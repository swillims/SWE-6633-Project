using System;

namespace ProjectManagementGui.Models;

public record LoggedEffortEntry(string RequirementName,
    string EffortType,
    string Description,
    DateTimeOffset Timestamp);
