using Microsoft.Data.Sqlite;
using ManufacturingEquipmentOrderProject.Models;

namespace ManufacturingEquipmentOrderProject.Services
{
    public class DatabaseService
    {
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS EquipmentOrders (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EQUIPMENT_NOMENCLATURE TEXT,
                    MESCI_CONTROL_POINT TEXT,
                    MODEL_NO TEXT,
                    USAGE_CODE TEXT,
                    EFFECTIVITY TEXT,
                    AUTHORITY_REMARKS TEXT,
                    SHOP_USE_DATE TEXT,
                    USING_DEPT TEXT,
                    CONTRACT_NO TEXT,
                    BUSINESS_ACTIVITY_CATEGORY TEXT,
                    EQUIPMENT_NUMBER TEXT,
                    SERIAL_NO TEXT,
                    QUANTITY INTEGER,
                    EQUIPMENT_CLASSIFICATION TEXT,
                    PROPERTY_CONTROL_NO TEXT,
                    SEQUENCE_NO TEXT,
                    MOD_NO TEXT,
                    CALIBRATION_REQUIRED TEXT,
                    DESIGN_HOURS INTEGER,
                    FAB_HOURS INTEGER,
                    EST_MATERIAL_COST REAL,
                    SELL_DATE TEXT,
                    ENGINEERING_STATUS TEXT,
                    MATERIAL_STATUS TEXT,
                    FABRICATION_STATUS TEXT,
                    DEPT_NOTES TEXT
                )";
            command.ExecuteNonQuery();
        }
    }

    public void SaveEquipmentOrder(EquipmentOrder order)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO EquipmentOrders (
                    EQUIPMENT_NOMENCLATURE, MESCI_CONTROL_POINT, MODEL_NO, USAGE_CODE, EFFECTIVITY,
                    AUTHORITY_REMARKS, SHOP_USE_DATE, USING_DEPT, CONTRACT_NO, BUSINESS_ACTIVITY_CATEGORY,
                    EQUIPMENT_NUMBER, SERIAL_NO, QUANTITY, EQUIPMENT_CLASSIFICATION, PROPERTY_CONTROL_NO,
                    SEQUENCE_NO, MOD_NO, CALIBRATION_REQUIRED, DESIGN_HOURS, FAB_HOURS, EST_MATERIAL_COST,
                    SELL_DATE, ENGINEERING_STATUS, MATERIAL_STATUS, FABRICATION_STATUS, DEPT_NOTES
                ) VALUES (
                    @EQUIPMENT_NOMENCLATURE, @MESCI_CONTROL_POINT, @MODEL_NO, @USAGE_CODE, @EFFECTIVITY,
                    @AUTHORITY_REMARKS, @SHOP_USE_DATE, @USING_DEPT, @CONTRACT_NO, @BUSINESS_ACTIVITY_CATEGORY,
                    @EQUIPMENT_NUMBER, @SERIAL_NO, @QUANTITY, @EQUIPMENT_CLASSIFICATION, @PROPERTY_CONTROL_NO,
                    @SEQUENCE_NO, @MOD_NO, @CALIBRATION_REQUIRED, @DESIGN_HOURS, @FAB_HOURS, @EST_MATERIAL_COST,
                    @SELL_DATE, @ENGINEERING_STATUS, @MATERIAL_STATUS, @FABRICATION_STATUS, @DEPT_NOTES
                )";

            command.Parameters.AddWithValue("@EQUIPMENT_NOMENCLATURE", order.EQUIPMENT_NOMENCLATURE);
            command.Parameters.AddWithValue("@MESCI_CONTROL_POINT", order.MESCI_CONTROL_POINT);
            command.Parameters.AddWithValue("@MODEL_NO", order.MODEL_NO);
            command.Parameters.AddWithValue("@USAGE_CODE", order.USAGE_CODE);
            command.Parameters.AddWithValue("@EFFECTIVITY", order.EFFECTIVITY);
            command.Parameters.AddWithValue("@AUTHORITY_REMARKS", order.AUTHORITY_REMARKS);
            command.Parameters.AddWithValue("@SHOP_USE_DATE", order.SHOP_USE_DATE.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@USING_DEPT", order.USING_DEPT);
            command.Parameters.AddWithValue("@CONTRACT_NO", order.CONTRACT_NO);
            command.Parameters.AddWithValue("@BUSINESS_ACTIVITY_CATEGORY", order.BUSINESS_ACTIVITY_CATEGORY);
            command.Parameters.AddWithValue("@EQUIPMENT_NUMBER", order.EQUIPMENT_NUMBER);
            command.Parameters.AddWithValue("@SERIAL_NO", order.SERIAL_NO);
            command.Parameters.AddWithValue("@QUANTITY", order.QUANTITY);
            command.Parameters.AddWithValue("@EQUIPMENT_CLASSIFICATION", order.EQUIPMENT_CLASSIFICATION);
            command.Parameters.AddWithValue("@PROPERTY_CONTROL_NO", order.PROPERTY_CONTROL_NO);
            command.Parameters.AddWithValue("@SEQUENCE_NO", order.SEQUENCE_NO);
            command.Parameters.AddWithValue("@MOD_NO", order.MOD_NO);
            command.Parameters.AddWithValue("@CALIBRATION_REQUIRED", order.CALIBRATION_REQUIRED);
            command.Parameters.AddWithValue("@DESIGN_HOURS", order.DESIGN_HOURS);
            command.Parameters.AddWithValue("@FAB_HOURS", order.FAB_HOURS);
            command.Parameters.AddWithValue("@EST_MATERIAL_COST", order.EST_MATERIAL_COST);
            command.Parameters.AddWithValue("@SELL_DATE", order.SELL_DATE.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@ENGINEERING_STATUS", order.ENGINEERING_STATUS);
            command.Parameters.AddWithValue("@MATERIAL_STATUS", order.MATERIAL_STATUS);
            command.Parameters.AddWithValue("@FABRICATION_STATUS", order.FABRICATION_STATUS);
            command.Parameters.AddWithValue("@DEPT_NOTES", order.DEPT_NOTES);

            command.ExecuteNonQuery();
        }
    }
}
}