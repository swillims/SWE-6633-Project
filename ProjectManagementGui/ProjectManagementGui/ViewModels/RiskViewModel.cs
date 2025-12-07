using System;
using ProjectManagementGui.Models;
using ReactiveUI;

namespace ProjectManagementGui.ViewModels;

public class RiskViewModel : ReactiveObject
{
    private readonly RiskModel _riskModel;
    
    private string _description = "";
    public string Description
    {
        get => _riskModel.Description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    private int _status;
    public int Status
    {
        get => _status;
        set
        {
            this.RaiseAndSetIfChanged(ref _status, value);
            _riskModel.RiskStatus = (RiskModel.Status)value;
        }
    }

    public RiskViewModel(string description)
    {
        _riskModel = new RiskModel(description);
        Description = _riskModel.Description;
        Status = (int)_riskModel.RiskStatus;
    }

    public int GetId()
    {
        return _riskModel.Id;
    }
}