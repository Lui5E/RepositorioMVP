using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FusionConsolaWindows_FaceAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const string subscriptionKey = "3bcd830af74a48ddac52df8e635c795f";
        public const string uriBase = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
        private void Form1_Load(object sender, EventArgs e)
        {
            
            string imageFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\captura0.jpg";
            MakeAnalysisRequest(imageFilePath);
        }

        static async void MakeAnalysisRequest(string imageFilePath)
        {
            HttpClient client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "3bcd830af74a48ddac52df8e635c795f");

            // Request parameters. A third optional parameter is "details".
            //string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=emotion";


            // Assemble the URI for the REST API Call.
            string uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            // Request body. Posts a locally stored JPEG image.
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                response = await client.PostAsync(uri, content);

                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();

                // Display the JSON response.
                
                MessageBox.Show(JsonPrettyPrint(contentString));
            }
        }


        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <returns>The byte array of the image data.</returns>
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }


        /// <summary>
        /// Formats the given JSON string by adding line breaks and indents.
        /// </summary>
        /// <param name="json">The raw JSON string to format.</param>
        /// <returns>The formatted JSON string.</returns>
        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            string solo_emociones = "";     //Cadena con unicamente las emociones y su valor
            int contador_llave = 0;     //Cada cuatro es emociones
            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                {
                    sb.Append(ch);
                    if (contador_llave == 4)
                    {
                        solo_emociones += ch;
                    }
                }
                else
                {
                    switch (ch)
                    {
                        case '{':
                            contador_llave++;
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            if (contador_llave == 4)
                            {
                                solo_emociones += ch;
                            }
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            if (contador_llave == 4)
                            {
                                solo_emociones += ch;
                            }
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            if (contador_llave == 4)
                            {
                                solo_emociones += ch;
                            }
                            break;
                    }
                }
            }
            MessageBox.Show(solo_emociones);
            return sb.ToString().Trim();
        }
    }
}
