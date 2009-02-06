using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.Framework;

namespace CryptoEditor.Notes
{
    [CryptoEditorPlugin("Notes")]
    public class CryptoNotes : CryptoEditorPlugin<CryptoNotesItem>
    {
        public CryptoNotes()
        {
            detail = new CryptoNotesDetail(this);
        }

        public override object CreateItem()
        {
            CryptoNotesEditionForm form = new CryptoNotesEditionForm();
            if(form.ShowDialog() != DialogResult.OK)
                return null;

            CryptoNotesItem item = new CryptoNotesItem();
            item.Title = form.titleTextBox.Text;
            item.Subject = form.subjectTextBox.Text;
            item.Author = form.authorTextBox.Text;
            item.Comments = form.commentsTextBox.Text;
            item.Keywords = form.keywordsTextBox.Text;
            item.Notes = form.notesTextBox.Text;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoNotesItem item = (CryptoNotesItem) itemIn;
            CryptoNotesEditionForm form = new CryptoNotesEditionForm();
            form.titleTextBox.Text = item.Title;
            form.subjectTextBox.Text = item.Subject;
            form.authorTextBox.Text = item.Author;
            form.commentsTextBox.Text = item.Comments;
            form.keywordsTextBox.Text = item.Keywords;
            form.notesTextBox.Text = item.Notes;

            if (form.ShowDialog() != DialogResult.OK)
                return null;

            item.Title = form.titleTextBox.Text;
            item.Subject = form.subjectTextBox.Text;
            item.Author = form.authorTextBox.Text;
            item.Comments = form.commentsTextBox.Text;
            item.Keywords = form.keywordsTextBox.Text;
            item.Notes = form.notesTextBox.Text;

            base.UpdateItem(item);
            return item;
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
