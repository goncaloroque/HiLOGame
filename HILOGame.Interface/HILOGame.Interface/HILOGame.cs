using HILOGameAPI;
using Microsoft.VisualBasic;
using System.Text;

namespace HILOGame.Interface
{
    public partial class HILOGame : Form
    {

        HILOGameAPIClient _HILOGameClient = new HILOGameAPIClient("https://localhost:7008", new HttpClient());
        List<GameResponse> _HILOGames = new List<GameResponse>();
        string playerID = "";
        string gameID = "";
        int minNumber = 0;
        int maxNumber = 0;


        public HILOGame()
        {
            InitializeComponent();
        }

        private async void btnPlayer_ClickAsync(object sender, EventArgs e)
        {
            var player = await _HILOGameClient.PostPlayerAsync(new PlayerRequest()
            {
                Name = txtPlayer.Text
            });
            playerID = player.Id;
            grpGame.Enabled = true;
        }

        private void lstGame_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void HILOGame_Load(object sender, EventArgs e)
        {
            LoadGameList();
        }

        private async void LoadGameList()
        {
            var result = await _HILOGameClient.GetGamesAsync();
            cboGame.Items.Clear();

            foreach (var game in result)
            {
                cboGame.Items.Add(new GameItem()
                {
                    ID = game.Id,
                    Description = game.Description
                });
            }
        }
        private async void cboGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = await _HILOGameClient.GetGameByIdAsync(((GameItem)cboGame.SelectedItem).ID);
            gameID = result.Id;
            minNumber = result.MinValue;
            maxNumber = result.MaxValue;

            if (result.GamePlayers.Count(player => player.PlayerID.CompareTo(Guid.Parse(playerID)) == 0) > 0)
            {
                EnableDisableAttempt(true);
            }
            else
            {
                EnableDisableAttempt(false);
            }

            LoadGameInfo(result);
        }

        private void EnableDisableAttempt(bool enable) {
            txtNumber.Enabled = enable;
            btnAttempt.Enabled = enable;
        }

        private void LoadGameInfo(GameResponse game)
        {
            StringBuilder gameInfo = new StringBuilder();

            gameInfo.AppendLine("NAME: " + game.Description);
            gameInfo.AppendLine("STATUS: " + game.Status);
            gameInfo.AppendLine("INTERVAL: " + game.MinValue + " - " + game.MaxValue);
            gameInfo.AppendLine("");
            gameInfo.AppendLine("PLAYERS [" + game.GamePlayers.Count + "]:");
            foreach (var player in game.GamePlayers)
            {
                gameInfo.AppendLine("   - " + player.Name);
            }
            txtGameDetails.Text = gameInfo.ToString();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gameID))
            {
                MessageBox.Show("Please select a game to join.");
                return;
            }

            var result = await _HILOGameClient.JoinGameAsync(new JoinGameRequest()
            {
                GameID = gameID,
                PlayerID = playerID
            });
            LoadGameInfo(result);
            EnableDisableAttempt(true);
        }

        private async void btnAttempt_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(gameID))
            {
                MessageBox.Show("Please join a game.");
                return;
            }

            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                MessageBox.Show("Invalid value");
                return;
            }

            if (int.Parse(txtNumber.Text)> maxNumber || int.Parse(txtNumber.Text) < minNumber)
            {
                MessageBox.Show("Number out of the range");
                return;
            }

            var result = await _HILOGameClient.GameAttemptAsync(new AttemptRequest()
            {
                GameID = gameID,
                PlayerID = playerID,
                Number = int.Parse(txtNumber.Text)
            });
            MessageBox.Show(result.Result, "HILOGame");
        }

        private async void btnNewGame_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMin.Text) || string.IsNullOrEmpty(txtMax.Text))
            {
                MessageBox.Show("Invalid range");
                return;
            }

            if (int.Parse(txtMin.Text) >= int.Parse(txtMax.Text))
            {
                MessageBox.Show("Invalid range");
                return;
            }

            if (string.IsNullOrEmpty(txtGameName.Text))
            {
                MessageBox.Show("Enter a game description");
                return;
            }

            await _HILOGameClient.CreateGameAsync(new GameRequest()
            {
                Description = txtGameName.Text,
                MinValue = int.Parse(txtMin.Text),
                MaxValue = int.Parse(txtMax.Text)
            });

            LoadGameList();
        }


    }
}