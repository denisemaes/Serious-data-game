using UnityEngine;
using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;
using TMPro;

public class DatabaseHandler : MonoBehaviour
{
	private string connectionString = "server=localhost;port=3306;database=Aceddwh;user=ACEDuser;password=Hxq3zK81Qwp!;CharSet=utf8;Connection Timeout=60";
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;

	[SerializeField]
	private TextMeshProUGUI autocorrectText;
	[SerializeField]
	private TMP_InputField answerInputField;

	// create a new connection to the database
	private MySqlConnection GetConnection()
	{
		return new MySqlConnection(connectionString);
	}

	private void Start()
	{
		//Adds a listener to the main input field and invokes a method when the value changes.
		answerInputField.onValueChanged.AddListener(delegate { DimLocationToNames(AnswerChangeCheck(answerInputField.text)); });
	}

	private List<string> DimLocationToNames(List<dimlocation> entityList)
	{
		List<string> nameList = new List<string>();

		foreach(dimlocation location in entityList)
		{
			nameList.Add(location.Name);
		}

		Debug.Log(nameList);
		return nameList;
	}

	public List<dimlocation> AnswerChangeCheck(string answerTextInput)
	{
		var list = new List<dimlocation>();

		using (con = GetConnection())
		{
			con.Open();

			Debug.Log(con.State);
			//var query = string.Format("SELECT * FROM WHERE Name LIKE {0}% ORDER BY Name", answerTextInput);
			var query = string.Format("SELECT * FROM aceddwh.dimlocation;");
			var cmd = new MySqlCommand(query, con);

			using (rdr = cmd.ExecuteReader())
			{
				while (rdr.Read())
				{
					list.Add(new dimlocation()
					{
						LocationId = Convert.ToInt32(rdr["LocationId"]),
						Name = rdr["Name"].ToString()
					});
				}
			}
		}

		return list;
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