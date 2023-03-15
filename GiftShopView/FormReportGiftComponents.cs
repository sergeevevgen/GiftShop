﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftShopContracts.BindingModels;
using GiftShopContracts.BusinessLogicsContracts;
using System.Windows.Forms;

namespace GiftShopView
{
    public partial class FormReportGiftComponents : Form
    {
        private readonly IReportLogic _logic;
        public FormReportGiftComponents(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportGiftComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetGiftComponent();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.GiftName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridView.Rows.Add(new object[]
                            {
                                "",
                                listElem.Item1,
                                listElem.Item2
                            });
                        }
                        dataGridView.Rows.Add(new object[]
                        {
                            "Итого",
                            "",
                            elem.TotalCount
                        });
                        //dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveGiftComponentsToExcelFile(
                    new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
    }
}
