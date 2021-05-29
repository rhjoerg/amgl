package ch.rhjoerg.amgl.content;

import java.io.File;
import java.io.InputStream;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse.BodyHandlers;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Collections;
import java.util.SortedSet;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Main
{
	private static HttpClient httpClient = HttpClient.newHttpClient();
	
	public static void main(String[] args) throws Exception
	{
		dax("http://download.eclipse.org/releases/2021-03/compositeContent.jar");
		dax("http://download.eclipse.org/releases/2021-03/202103171000/content.jar");
		
		units("downloads/download.eclipse.org/releases/2021-03/202103171000/content/content.xml");
	}
	
	private static Path path(String src) throws Exception
	{
		URI uri = new URI(src);
		
		return Path.of("downloads", uri.getHost(), uri.getPath());
	}
	
	private static void dax(String src) throws Exception
	{
		download(src);
		extract(src);
	}
	
	private static void download(String src) throws Exception
	{
		Path path = path(src);
		
		if (Files.exists(path))
			return;
		
		Files.createDirectories(path.getParent());
		httpClient.send(HttpRequest.newBuilder(new URI(src)).GET().build(), BodyHandlers.ofFile(path));
	}
	
	private static void extract(String src) throws Exception
	{
		Path folder = folder(src);
		Path path = path(src);
		
		try (ZipFile zip = new ZipFile(path.toFile()))
		{
			for (ZipEntry entry : Collections.list(zip.entries()))
			{
				try (InputStream is = zip.getInputStream(entry))
				{
					Path out = folder.resolve(entry.getName());
					
					if (Files.exists(out))
						continue;
					
					Files.createDirectories(out.getParent());
					Files.copy(is, out);
				}
			}
		}
	}
	
	private static Path folder(String src) throws Exception
	{
		return path(src.substring(0, src.lastIndexOf('.')));
	}
	
	private static void units(String src) throws Exception
	{
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = dbf.newDocumentBuilder();
		Document doc = db.parse(new File(src));
		NodeList elems = doc.getElementsByTagName("unit");
		SortedSet<String> units = new TreeSet<>();
		
		for (int i = 0, n = elems.getLength(); i < n; ++i)
		{
			Node node = elems.item(i);
			Element element = (Element) node;
			String id = element.getAttribute("id");
			
			units.add(id);
		}
		
		Files.write(Path.of(src + ".txt"), units);
	}
}
