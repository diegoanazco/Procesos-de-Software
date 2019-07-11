package com.example.uprocesos;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;

public class MainActivity extends AppCompatActivity {
    Button siguiente;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        siguiente = (Button)findViewById(R.id.button2);
    }

    public void Login_Ingresar(View v)
    {
        Thread nt = new Thread()
        {

            EditText usuario = (EditText)findViewById(R.id.login_Usuario);
            EditText password = (EditText)findViewById(R.id.login_Password_X);

            String res;





            @Override
            public void run()
            {
                String NAMESPACE = "http://tempuri.org/";
                String URL = "http://192.168.22.206:45455//WebService1.asmx";
                String METHOD_NAME = "Admin_Login";
                String SOAP_ACTION = "http://tempuri.org/Admin_Login";

                SoapObject request = new SoapObject(NAMESPACE,METHOD_NAME);
                request.addProperty("usuario", usuario.getText().toString());
                request.addProperty("contrasena",password.getText().toString());

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                envelope.dotNet=true;

                envelope.setOutputSoapObject(request);
                HttpTransportSE transporte = new HttpTransportSE(URL);

                try
                {
                    transporte.call(SOAP_ACTION,envelope);
                    SoapPrimitive resultado_xml = (SoapPrimitive) envelope.getResponse();
                    res = resultado_xml.toString();
                }catch(IOException e){
                    e.printStackTrace();
                }catch (XmlPullParserException e)
                {
                    e.printStackTrace();
                }

                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(MainActivity.this,res,Toast.LENGTH_LONG).show();
                        TextView result = (TextView) findViewById(R.id.textView3);


                        if(res.equals("null"))
                        {
                            res = "DATOS INCORRECTOS";
                            result.setText(res);

                        }
                        else
                        {
                            Intent siguiente = new Intent(MainActivity.this,MainPage.class);
                            startActivity(siguiente);
                        }

                    }
                });

            }
        };

        nt.start();
    }
}
