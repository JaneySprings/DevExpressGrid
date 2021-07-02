using DevExpress.XamarinForms.DataGrid;
using DevExpressGrid.network;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevExpressGrid.presentation {
    class GridPresenter {
        private DataGridView grid;
        private List<ValueModel> items;

        public GridPresenter(DataGridView parent, List<ValueModel> mItems) {
            grid = parent;
            items = mItems;
        }

        /* Perform add data to grid */
        public void initComponents() {
          
            grid.ItemsSource = items;
        }


        /* Resolve state on unit value */
        private UnitStates resolveState(int count) {
            if (count < 2) return UnitStates.LOW;
            else if (count < 6) return UnitStates.ENOUGHT;
            else return UnitStates.HUGE;
        }

        /* Unit count states */
        private enum UnitStates { LOW, ENOUGHT, HUGE }
    }
}
