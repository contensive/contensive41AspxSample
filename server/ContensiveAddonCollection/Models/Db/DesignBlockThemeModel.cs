﻿
using Contensive.Models.Db;

namespace Contensive.Addons.SampleCollection {
    namespace Models.Db {
        // 
        /// <summary>
        ///     ''' This model provides the common fields for all Design Blocks.
        ///     ''' </summary>
        public class DesignBlockThemeModel : DbBaseModel {
            // 
            // ====================================================================================================
            /// <summary>
            /// metadata
            /// </summary>
            public static  DbBaseTableMetadataModel tableMetadata { get; } = new DbBaseTableMetadataModel("Design Block Themes", "dbthemes", "default", false);
            // 
            // ====================================================================================================
            // -- instance properties
        }
    }
}