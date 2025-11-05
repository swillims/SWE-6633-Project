using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE_6633_App.Models
{
    internal class DataModelComponents
    {
    }

    public class Project
    {
        string manager = ""; // I don't believe the requirements need manager extra functionality. String should be fine.
        List<String> teamMembers = new List<String>(); // I don't believe the requirements need team member extra functionality. String should be fine.
        List<Risk> risks = new List<Risk>();
        List<FunctionalRequirements> functionalRequirements = new List<FunctionalRequirements>();
        List<NonFunctionalRequirements> nonFunctionalRequirements = new List<NonFunctionalRequirements>();

        static Project? currentProject; // variable part of the "not singleton".
        public Project() // I don't want to explain this. It's singleton adjacent. It's not a singleton because it allows multiple implmentation.
        {
            if (currentProject == null)
            {
                currentProject = this;
            }
        }

    }
    enum RISKSTATUS // I forgot which Risk Statuses there were
    {
        high,medium,low,undeclared
    }
    public class Risk
    {
        string name = "default";
        string description = "no description";
        RISKSTATUS riskStatus = RISKSTATUS.undeclared; // enum
    }
    enum DEVELOPMENTPHASE
    {
        // first 5 are from the high level description of project and last one is a default value
        requirementsAnalysis, designing, coding, testing, projectManagement, none
    }
    public class FunctionalRequirements
    {
        string name = "default";
        string description = "no description";
        float hoursSpent = 0f; // float instead of int
        DEVELOPMENTPHASE developmentPhase = DEVELOPMENTPHASE.none;
    }
    public class NonFunctionalRequirements
    {
        // IMPORTANT READ THIS : "by each of the earlier entered requirements" does not specify functional, so it applies to non-functional
        string name = "default";
        string description = "no description";
        float hoursSpent = 0f; // float instead of int
        DEVELOPMENTPHASE developmentPhase = DEVELOPMENTPHASE.none;
    }
}
