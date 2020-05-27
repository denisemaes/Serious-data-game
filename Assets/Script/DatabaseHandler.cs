using UnityEngine;
using System;
using System.Data;
using System.Text;
using Model;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
//using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;
using TMPro;

public class DatabaseHandler : MonoBehaviour
{
	private string connectionString = "Server=localhost;Database=aceddwh;Uid=root;Pwd=admin;pooling=true;Charset=utf8;port=3306";
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;

	[SerializeField]
	private TextMeshProUGUI autocorrectText;
	[SerializeField]
	private TMP_InputField answerInput;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		


		//var con2 = new MySqlConnection(connectionString);
		//con2.Open();

		try
		{
			con = new MySqlConnection(connectionString);
			con.Open();
			var something = con.State;
			Debug.Log("Mysql state: " + con.State);


			var query = String.Format("SELECT COUNT(LocationId) FROM aceddwh.dimlocation where locationid = 1;");


			cmd = new MySqlCommand(query, con);
			object result = cmd.ExecuteScalar();

			con.Close();
		}
		catch (Exception e)
		{
			Debug.Log(e);
		}
	}

	private void Start()
	{
		//Adds a listener to the main input field and invokes a method when the value changes.
		answerInput.onValueChanged.AddListener(delegate { AnswerChangeCheck(); });
	}

	public void AnswerChangeCheck()
	{
		//string sql = "SELECT * FROM dimlocation" +
		//	"			WHERE Name Like" + answerInput.text + "%";

		//var query = String.Format("SELECT * FROM aceddwh.dimlocation WhHERE Name Like {0}  ", "'Vlielan%'");

		var connection = new MySqlConnection(connectionString);

		using (connection)
		{
			connection.Open();
			var query = String.Format("SELECT COUNT(LocationId) FROM aceddwh.dimlocation where locationid = 1;");


			//var cmd2 = connection.CreateCommand();
			//cmd2.CommandText = query;
			//cmd2.CommandType = CommandType.Text;
			//cmd2.CommandTimeout = 60;
			//var reader = cmd2.ExecuteReader();

			cmd = new MySqlCommand(query, connection);
			object result = cmd.ExecuteScalar();




			try
			{
				




				if (rdr.HasRows)
				{
					while (rdr.Read())
					{
						//string r = Convert.ToString(result);
						//autocorrectText.text = r;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			Debug.Log(connection.State);
		}

	}

	void onApplicationQuit()
	{
		if (con != null)
		{
			if (con.State.ToString() != "Closed")
			{
				con.Close();
				Debug.Log("Mysql connection closed");
			}
			con.Dispose();
		}
	}

	

	public string GetConnectionState()
	{
		return con.State.ToString();
	}
}