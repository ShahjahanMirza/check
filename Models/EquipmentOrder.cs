namespace ManufacturingEquipmentOrderProject.Models{
public class EquipmentOrder
{
public required string EQUIPMENT_NOMENCLATURE { get; set; }
public required string MESCI_CONTROL_POINT { get; set; }
public required string MODEL_NO { get; set; }
public required string USAGE_CODE { get; set; }
public required string EFFECTIVITY { get; set; }
public required string AUTHORITY_REMARKS { get; set; }
public required string USING_DEPT { get; set; }
public required string CONTRACT_NO { get; set; }
public required string BUSINESS_ACTIVITY_CATEGORY { get; set; }
public required string EQUIPMENT_NUMBER { get; set; }
public required string SERIAL_NO { get; set; }
public required string EQUIPMENT_CLASSIFICATION { get; set; }
public required string PROPERTY_CONTROL_NO { get; set; }
public required string SEQUENCE_NO { get; set; }
public required string MOD_NO { get; set; }
public required string CALIBRATION_REQUIRED { get; set; }
public required string ENGINEERING_STATUS { get; set; }
public required string MATERIAL_STATUS { get; set; }
public required string FABRICATION_STATUS { get; set; }
public required string DEPT_NOTES { get; set; }
public DateTime SHOP_USE_DATE { get; set; }
public int QUANTITY { get; set; }
public int DESIGN_HOURS { get; set; }
public int FAB_HOURS { get; set; }
public decimal EST_MATERIAL_COST { get; set; }
public DateTime SELL_DATE { get; set; }
}
}
