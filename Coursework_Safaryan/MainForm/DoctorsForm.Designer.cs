namespace PL
{
    partial class DoctorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Initials = new System.Windows.Forms.TextBox();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fromTime = new System.Windows.Forms.TextBox();
            this.toTime = new System.Windows.Forms.TextBox();
            this.nonDaysOfWeek = new System.Windows.Forms.TextBox();
            this.Speciality = new System.Windows.Forms.ComboBox();
            this.createNewBut = new System.Windows.Forms.Button();
            this.NameError = new System.Windows.Forms.Label();
            this.AgeError = new System.Windows.Forms.Label();
            this.SpecialityError = new System.Windows.Forms.Label();
            this.TimeError = new System.Windows.Forms.Label();
            this.DayError = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Управління лікарями";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Видалити данного лікаря";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // doctorsBox
            // 
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Items.AddRange(new object[] {
            "Реабілітолог",
            "Ревматолог",
            "Рентгенолог",
            "Рефлексотерапевт",
            "Сексолог (Сексопатолог)",
            "Сімейний лікар",
            "Фахівець з клітинних технологій",
            "Спортивний лікар",
            "Стоматолог (Дантист)",
            "Терапевт",
            "Токсиколог",
            "Травматолог",
            "Трансплантолог",
            "Уролог",
            "Фармацевт",
            "Фоніатр",
            "Фтизіатр",
            "Хірург",
            "Ембріолог",
            "Ендокринолог",
            "Ендоскопіст",
            "Епідеміолог",
            "Еферентолог",
            "Мамолог (Онколог-мамолог)",
            "Мануальний терапевт (Мануальник/Остеопат)",
            "Медична сестра (Медсестра)",
            "Міколог",
            "Нарколог",
            "Невролог (Невропатолог)",
            "Нейрохірург",
            "Неонатолог",
            "Нефролог",
            "Нутриціолог",
            "Онколог (Хірург - онколог)",
            "Ортопед",
            "Оториноларинголог (отоларинголог, ЛОР)",
            "Офтальмолог (Окуліст)",
            "Патологоанатом",
            "Педіатр",
            "Подолог",
            "Провізор",
            "Проктолог",
            "Психіатр",
            "Психотерапевт",
            "Пульмонолог",
            "Радіолог",
            "Акушер-гінеколог",
            "Алерголог-імунолог",
            "Андролог",
            "Анестезіолог-реаніматолог",
            "Ароматерапевт",
            "Бактеріолог",
            "Венеролог",
            "Вертебролог",
            "Лікар швидкої допомоги",
            "Лікар функціональної діагностики (Функціональний діагност)",
            "Гастроентеролог",
            "Гематолог",
            "Геріатр (Геронтолог)",
            "Гірудотерапевт",
            "Дерматолог",
            "Дієтолог",
            "Інфекціоніст",
            "Кардіолог",
            "Кардіохірург",
            "Кінезітерапевт",
            "Комбустіолог (Опіковий хірург)",
            "Косметолог"});
            this.doctorsBox.Location = new System.Drawing.Point(232, 16);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(242, 28);
            this.doctorsBox.TabIndex = 2;
            this.doctorsBox.SelectedIndexChanged += new System.EventHandler(this.doctorsBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ім\'я";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 53);
            this.button2.TabIndex = 4;
            this.button2.Text = "Зберегти зміни";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Вік:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Спеціалізація:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Час прийому:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Робочі дні тижня:";
            // 
            // Initials
            // 
            this.Initials.Location = new System.Drawing.Point(116, 60);
            this.Initials.Name = "Initials";
            this.Initials.Size = new System.Drawing.Size(162, 26);
            this.Initials.TabIndex = 9;
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(122, 191);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(100, 26);
            this.ageBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "з";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "до";
            // 
            // fromTime
            // 
            this.fromTime.Location = new System.Drawing.Point(228, 278);
            this.fromTime.Name = "fromTime";
            this.fromTime.Size = new System.Drawing.Size(74, 26);
            this.fromTime.TabIndex = 14;
            // 
            // toTime
            // 
            this.toTime.Location = new System.Drawing.Point(372, 278);
            this.toTime.Name = "toTime";
            this.toTime.Size = new System.Drawing.Size(71, 26);
            this.toTime.TabIndex = 15;
            // 
            // nonDaysOfWeek
            // 
            this.nonDaysOfWeek.Location = new System.Drawing.Point(209, 329);
            this.nonDaysOfWeek.Name = "nonDaysOfWeek";
            this.nonDaysOfWeek.Size = new System.Drawing.Size(222, 26);
            this.nonDaysOfWeek.TabIndex = 16;
            // 
            // Speciality
            // 
            this.Speciality.FormattingEnabled = true;
            this.Speciality.Location = new System.Drawing.Point(181, 233);
            this.Speciality.Name = "Speciality";
            this.Speciality.Size = new System.Drawing.Size(262, 28);
            this.Speciality.TabIndex = 17;
            // 
            // createNewBut
            // 
            this.createNewBut.Location = new System.Drawing.Point(438, 394);
            this.createNewBut.Name = "createNewBut";
            this.createNewBut.Size = new System.Drawing.Size(142, 53);
            this.createNewBut.TabIndex = 18;
            this.createNewBut.Text = "Додати нового лікаря";
            this.createNewBut.UseVisualStyleBackColor = true;
            this.createNewBut.Click += new System.EventHandler(this.createNewBut_Click);
            // 
            // NameError
            // 
            this.NameError.AutoSize = true;
            this.NameError.Location = new System.Drawing.Point(639, 150);
            this.NameError.Name = "NameError";
            this.NameError.Size = new System.Drawing.Size(51, 20);
            this.NameError.TabIndex = 19;
            this.NameError.Text = "label9";
            // 
            // AgeError
            // 
            this.AgeError.AutoSize = true;
            this.AgeError.Location = new System.Drawing.Point(639, 191);
            this.AgeError.Name = "AgeError";
            this.AgeError.Size = new System.Drawing.Size(51, 20);
            this.AgeError.TabIndex = 20;
            this.AgeError.Text = "label9";
            // 
            // SpecialityError
            // 
            this.SpecialityError.AutoSize = true;
            this.SpecialityError.Location = new System.Drawing.Point(639, 236);
            this.SpecialityError.Name = "SpecialityError";
            this.SpecialityError.Size = new System.Drawing.Size(51, 20);
            this.SpecialityError.TabIndex = 21;
            this.SpecialityError.Text = "label9";
            // 
            // TimeError
            // 
            this.TimeError.AutoSize = true;
            this.TimeError.Location = new System.Drawing.Point(639, 281);
            this.TimeError.Name = "TimeError";
            this.TimeError.Size = new System.Drawing.Size(51, 20);
            this.TimeError.TabIndex = 22;
            this.TimeError.Text = "label9";
            // 
            // DayError
            // 
            this.DayError.AutoSize = true;
            this.DayError.Location = new System.Drawing.Point(639, 335);
            this.DayError.Name = "DayError";
            this.DayError.Size = new System.Drawing.Size(51, 20);
            this.DayError.TabIndex = 23;
            this.DayError.Text = "label9";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(616, 394);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 53);
            this.button4.TabIndex = 24;
            this.button4.Text = "Повернутись до головної";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(116, 103);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(162, 26);
            this.SurnameBox.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Прізвище";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 150);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 26);
            this.textBox2.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "По-батькові";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(639, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "label9";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(639, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "label9";
            // 
            // DoctorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 485);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.DayError);
            this.Controls.Add(this.TimeError);
            this.Controls.Add(this.SpecialityError);
            this.Controls.Add(this.AgeError);
            this.Controls.Add(this.NameError);
            this.Controls.Add(this.createNewBut);
            this.Controls.Add(this.Speciality);
            this.Controls.Add(this.nonDaysOfWeek);
            this.Controls.Add(this.toTime);
            this.Controls.Add(this.fromTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.Initials);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "DoctorsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Initials;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fromTime;
        private System.Windows.Forms.TextBox toTime;
        private System.Windows.Forms.TextBox nonDaysOfWeek;
        private System.Windows.Forms.ComboBox Speciality;
        private System.Windows.Forms.Button createNewBut;
        private System.Windows.Forms.Label NameError;
        private System.Windows.Forms.Label AgeError;
        private System.Windows.Forms.Label SpecialityError;
        private System.Windows.Forms.Label TimeError;
        private System.Windows.Forms.Label DayError;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}