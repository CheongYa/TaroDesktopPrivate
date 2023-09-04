using Tarot.UI;
using Resources = Tarot.Properties.Resources;

namespace Tarot.Forms
{
    public partial class TarotForm : Form
    {
        private Point _mousePoint;

        public TarotForm()
        {
            InitializeComponent();

            // �� �ڵ� §�� �׽�Ʈ �غ���.
            // this.cardControl1.setVisible(false);
        }

        private void TarotForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CardView card = new CardView("",Resources.iu, Resources.c20556fee77525a3,"");
                    Controls.Add(card);
                    int x = (j * card.Width) / 2;
                    int y = (i * card.Height) / 2;
                    card.Location = new Point(x, y);
                    card.MouseMove += onCardMouseDrag;
                    card.MouseDown += onCardMouseDown;
                }
            }
        }

        #region Event Method
        // ī�带 ���콺�� �巡�� �� ��, ī�� ������
        private void onCardMouseDrag(object? sender, MouseEventArgs e)  // ? = nullable
        {
            if (sender == null) return;
            CardView card = (CardView)sender;
            if (e.Button == MouseButtons.Left)
            {
                card.Left = e.X + card.Left - _mousePoint.X;
                card.Top = e.Y + card.Top - _mousePoint.Y;
                card.BringToFront();
            }
        }

        // ī�带 ���콺�� Ŭ���� ��, �� ��ġ�� ����
        private void onCardMouseDown(object? sender, MouseEventArgs e)
        {
            if (sender == null) return;
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }
        #endregion
    }
}