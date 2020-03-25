    using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManualDataBinding.Data;

namespace ManualDataBinding.UI
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : UserControl
    {
        public NoteEditor()
        {
            InitializeComponent();
        }

        private Note note;
        /// <summary>
        /// The note that will be editedS
        /// </summary>
        public Note Note
        {
            get { return note; }
            set 
            {
                if (note != null) note.NoteChanged -= OnNoteChanged;
                note = value;
                if (note != null)
                {
                    note.NoteChanged += OnNoteChanged;
                    OnNoteChanged(note, new EventArgs());
                }
            }
        }

        /// <summary>
        /// event handler that occurs when the note is updated 
        /// </summary>
        /// <param name="sender">note is changed</param>
        /// <param name="e">event arguments </param>
        public void OnNoteChanged(object sender, EventArgs e)
        {
            if (Note == null) return;
            Title.Text = Note.Title;
            Body.Text = Note.Body;
        }

        /// <summary>
        /// Notifies when editor title gets changed and changes the note to fit
        /// </summary>
        /// <param name="sender">change in text</param>
        /// <param name="e">event arguments</param>
        public void OnTitleChanged(object sender, TextChangedEventArgs e)
        {
            Note.Title = Title.Text;

        }
        /// <summary>
        /// Notifies when editor body gets changed and changes the note to fit
        /// </summary>
        /// <param name="sender">change in text</param>
        /// <param name="e">event arguments</param>
        public void OnBodyChanged(object sender, TextChangedEventArgs e)
        {
            Note.Body = Body.Text;
        }
    }
}
