using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Text
{
    [CryptoEditorPlugin("Text Documents")]
    public class CryptoText : CryptoEditorPlugin<CryptoTextItem>
    {
        public CryptoText()
        {
            detail = new CryptoTextDetail(this);
        }

        public override object CreateItem()
        {
            CryptoTextEditionForm form = new CryptoTextEditionForm();
            if(form.ShowDialog() != DialogResult.OK)
                return null;

            CryptoTextItem item = new CryptoTextItem();
            item.Title = form.titleTextBox.Text;
            item.Subject = form.subjectTextBox.Text;
            item.Author = form.authorTextBox.Text;
            item.Comments = form.commentsTextBox.Text;
            item.Keywords = form.keywordsTextBox.Text;
            item.Notes = form.notesTextBox.Text;

            base.CreateItem();
            return item;
        }

        public override object CreateItem(string dragDropText)
        {
            CryptoTextEditionForm form = new CryptoTextEditionForm();
            form.notesTextBox.Text = dragDropText;

            if (form.ShowDialog() != DialogResult.OK)
                return null;

            CryptoTextItem item = new CryptoTextItem();
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
            CryptoTextItem item = (CryptoTextItem) itemIn;
            CryptoTextEditionForm form = new CryptoTextEditionForm();
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
