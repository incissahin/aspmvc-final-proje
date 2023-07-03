using App.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Seeders
{

	public static class DbSeeder
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
				.HasData(new List<Category>()
				{
					new()
					{
						Id = 1,
						Name = "Sağlık",
						Description = "Sağlık hakkında tüm içerikler",
						CreatedAt = DateTime.Now,
					},
					new()
					{
						Id = 2,
						Name = "Ekipmanlar",
						Description = "Sağlık Ekipmanları",
						CreatedAt = DateTime.Now,
					},
					new()
					{
						Id = 3,
						Name = "Kalp",
						Description = "Kalp Sağlığı",
						CreatedAt = DateTime.Now,
					},
					new()
					{
						Id = 4,
						Name = "Ücretsiz Danışmanlık",
						Description = "Ücretsiz Danışmanlık Hizmeti",
						CreatedAt = DateTime.Now,
					},
					new()
					{
						Id = 5,
						Name = "Laboratuvar Testleri",
						Description = "Laboratuvar testleri hakkındaki içerikler"
					}
				});

			modelBuilder.Entity<User>().HasData(
				new List<User>()
				{
					new()
					{
						Id = 1,
						Email = "sample@admin.com",
						Password = "password",
						PasswordConfirm = "password",
						Name = "admin",
						City = "Silicon Valley",
						Phone = "05432105443",
						IsAdmin = true,
					},
					new()
					{
						Id = 2,
						Email = "sample@user.com",
						Password = "password",
						PasswordConfirm = "password",
						Name = "Tivorlu İso",
						City = "Vela vela velvela",
						Phone = "05432105443"
					}
				});

			modelBuilder.Entity<Post>().HasData(
				new List<Post>()
				{
					new()
					{
						Id = 1,
						UserId = 1,
						Title = "Bilim İnsanlarından Yeni Bir Sağlık Keşfi: Spor, Zihinsel Sağlık Üzerinde Olumlu Etki Yaratıyor!",
						Content = "Son araştırmalar, düzenli olarak spor yapmanın sadece fiziksel sağlığa değil, aynı zamanda zihinsel sağlık üzerinde de olumlu etkileri olduğunu ortaya koyuyor. Sağlık alanında önemli bir adım olarak kabul edilen bu keşif, birçok insanın daha sağlıklı ve dengeli bir yaşam sürmelerine yardımcı olabilecek potansiyele sahip.\r\n\r\nBilim insanları, sporun zihinsel sağlık üzerindeki faydalarını araştırmak için kapsamlı bir çalışma yürüttü. Araştırma sonuçları, düzenli egzersizin depresyon, stres, kaygı gibi zihinsel sağlık sorunlarıyla mücadelede etkili bir strateji olduğunu gösterdi. Spor yapmanın beyinde mutluluk hormonu olan endorfin salınımını artırdığı ve serotonin seviyelerini dengelediği tespit edildi. Bu da ruh halinin iyileşmesine, stresin azalmasına ve genel zihinsel sağlığın güçlenmesine katkıda bulunuyor.",
						CreatedAt = DateTime.Now,
					},
					new()
					{
						Id = 2,
						UserId = 1,
						Title = "Uyku ve Sağlık İlişkisi: Kaliteli Uyku, İyi Bir Fiziksel ve Zihinsel Sağlığın Anahtarı",
						Content = "Uyku, sağlıklı bir yaşam için hayati öneme sahip bir unsurdur ve son araştırmalar, kaliteli uykuyla fiziksel ve zihinsel sağlık arasındaki güçlü bağlantıyı doğruluyor. Uyku düzeninin düzgün bir şekilde sürdürülmesi, birçok sağlık sorununun önlenmesinde ve iyileştirilmesinde etkili bir strateji olarak öne çıkıyor.\r\n\r\nUyku eksikliği, birçok sağlık problemine yol açabilir. Son araştırmalar, düşük uyku kalitesinin obezite, diyabet, kalp hastalıkları ve bağışıklık sistemi sorunları gibi kronik hastalıklarla ilişkili olduğunu gösteriyor. Uyku düzeninin bozulması, hormonal dengenin değişmesine, iştah kontrolünün zayıflamasına ve enerji seviyelerinin düşmesine neden olabilir.",
						CreatedAt = DateTime.Now,
					}
				});


			modelBuilder.Entity<CategoryPost>().HasData(
				new List<CategoryPost>()
				{
					new()
					{
						Id = 1,
						PostId = 1,
						CategoryId = 1
					},
					new()
					{
						Id = 2,
						PostId = 2,
						CategoryId = 1
					},
				});

			modelBuilder.Entity<PostComment>().HasData(
				new List<PostComment>()
				{
					new()
					{
						Id = 1,
						PostId = 1,
						UserId= 2,
						Comment = "Şukunu verdim.",
						IsActive = true,
					},
					new()
					{
						Id = 2,
						PostId = 1,
						UserId= 2,
						Comment = "Bunlar hep bilgi.",
						IsActive = true,
					},
				});

			modelBuilder.Entity<PostImage>().HasData(
				new List<PostImage>()
				{
					new PostImage()
					{
						Id = 1,
						PostId = 1,
						ImagePath = "spor.jpg",
					},
					new PostImage()
					{
						Id = 2,
						PostId = 2,
						ImagePath = "uyku.jpg",
					}
				});

			modelBuilder.Entity<Department>().HasData(
				new List<Department>()
				{
					new()
					{
						Id = 1,
						Title = "Kardiyoloji",
						Description = "Kalbiniz İçin Özenle Tasarlandı\r\n\r\nSağlıklı bir yaşamın temel taşlarından biri olan kalp sağlığı, hayati öneme sahiptir. Kardiyoloji Departmanı olarak, kalp sağlığınızı korumak, teşhis etmek ve tedavi etmek için en son teknolojileri ve uzman kadromuzu birleştiriyoruz.\r\n\r\nKardiyoloji Departmanımız, deneyimli kardiyologlar, uzman hemşireler ve teknisyenlerden oluşan bir ekip tarafından yönetilmektedir. Her bir ekip üyemiz, kalp hastalıklarının teşhisi ve tedavisi konusunda geniş bir bilgi birikimine ve uzmanlığa sahiptir.\r\n\r\nGelişmiş tanı yöntemleriyle donatılmış olan departmanımızda, kalp rahatsızlıklarının kesin tanısını koymak için modern görüntüleme teknikleri, elektrokardiyografi (EKG), eko ve stres testi gibi yöntemler kullanılmaktadır. Ayrıca, kateter laboratuvarımızda anjiyografi, anjiyoplasti ve stent yerleştirme gibi invaziv işlemler gerçekleştirilmektedir.",
						ImagePath = "kardiyoloji.jpg"
					},
					new()
					{
						Id = 2,
						Title = "Diş Sağlığı",
						Description = "Sağlıklı Bir Gülümseme İçin Uzman Diş Sağlığı Hizmetleri\r\n\r\nDiş sağlığı, genel sağlığınızı etkileyen önemli bir faktördür. Dişlerinizin sağlığını korumak, estetik bir gülümsemeye sahip olmak ve ağız hijyeninizi sürdürmek için Diş Sağlığı Departmanı olarak buradayız.\r\n\r\nDeneyimli ve uzman diş hekimlerimiz, gelişmiş tedavi yöntemleri ve modern teknolojilerle donatılmış kliniğimizde hizmet vermektedir. İhtiyaçlarınızı ve beklentilerinizi karşılamak için kişiselleştirilmiş bir yaklaşım benimsiyoruz.\r\n\r\nDiş Sağlığı Departmanımız, çeşitli diş rahatsızlıklarının teşhisi, tedavisi ve önlenmesi konularında uzmanlaşmış bir ekip tarafından yönetilmektedir. Diş çürükleri, diş eti hastalıkları, diş kayıpları, kök kanal tedavisi, diş beyazlatma, diş protezleri ve estetik diş hekimliği gibi birçok alanda kapsamlı hizmetler sunmaktayız.",
						ImagePath = "dis.png"
					},
					new()
					{
						Id = 3,
						Title = "Jinekoloji",
						Description = "Kadın Sağlığına Önem Veren Uzman Jinekoloji Departmanı\r\n\r\nKadın sağlığı, yaşam kalitesi ve refahının temel taşlarından biridir. Jinekoloji Departmanı olarak, kadınların sağlığını korumak, önleyici tedbirler almak ve tedavi etmek için uzman kadromuz ve modern tıbbi ekipmanlarımızla buradayız.\r\n\r\nDeneyimli jinekologlarımız, gizlilik, güvenlik ve hasta memnuniyeti odaklı bir yaklaşımla hizmet vermektedir. Kadın sağlığına ilişkin tüm sorunlarınızı güvenle paylaşabileceğiniz, konforlu bir ortamda size özel bir tedavi sunmaktayız.\r\n\r\nJinekoloji Departmanımız, kadınların genel sağlığı, doğurganlık, gebelik ve doğum, kadın hastalıkları, jinekolojik kanserler, jinekolojik enfeksiyonlar ve menopoz gibi birçok alanda kapsamlı hizmetler sunmaktadır.",					
						ImagePath = "jinekoloji.jpeg"
					},
					new()
					{
						Id = 4,
						Title = "Nöroloji",
						Description = "Sinir Sisteminizi Önemseyen Uzman Nöroloji Departmanı\r\n\r\nNöroloji Departmanı olarak, sinir sistemi sağlığınızı korumak, teşhis etmek ve tedavi etmek için deneyimli ve uzman kadromuzla buradayız. Sinir sistemi, vücudunuzun en karmaşık ve önemli sistemlerinden biridir ve biz sizin yanınızdayız.\r\n\r\nNöroloji Departmanımız, çeşitli nörolojik rahatsızlıkların tanısı, tedavisi ve takibi konusunda uzmanlaşmış bir ekip tarafından yönetilmektedir. Baş ağrıları, inme, epilepsi, beyin tümörleri, hareket bozuklukları, uyku bozuklukları ve demans gibi birçok alanda kapsamlı hizmetler sunmaktayız.\r\n\r\nDeneyimli nörologlarımız, gelişmiş görüntüleme teknikleri, sinir ileti testleri ve diğer tanısal prosedürlerle nörolojik hastalıkları teşhis etmektedir. Tedavi planları, bireysel ihtiyaçlarınızı karşılamak üzere kişiselleştirilir ve en son tedavi yöntemleri ve ilaçlar kullanılarak uygulanır.",
						ImagePath = "noroloji.jpg"
					},


				});

			modelBuilder.Entity<Service>().HasData(
				new List<Service>()
				{
							new(){Id = 1, Title="İnvaziv işlemler", DepartmentId = 1},
							new(){Id = 2, Title="İlaç tedavisi", DepartmentId = 1},
							new(){Id = 3, Title="Kalp kapakçığı onarımı ve değişimi", DepartmentId = 1},
							new(){Id = 4, Title="Koroner bypass ameliyatı", DepartmentId = 1},
							new(){Id = 5, Title="Diş temizliği ve ağız hijyeni eğitimi", DepartmentId = 2},
							new(){Id = 6, Title= "Diş çürüklerinin tedavisi ve dolgu uygulamaları", DepartmentId = 2},
							new(){Id = 7, Title= "Diş eti hastalıklarının teşhisi ve tedavisi", DepartmentId = 2},
							new(){Id = 8, Title= "Kanal tedavisi ve kök ucu cerrahisi", DepartmentId = 2},
							new(){Id = 9, Title="Jinekolojik muayeneler ve sağlık taramaları", DepartmentId = 3},
							new(){Id = 10, Title="Smear testi (servikal kanser taraması)", DepartmentId = 3},
							new(){Id = 11, Title="Ultrason incelemeleri (pelvik ultrason, transvajinal ultrason)", DepartmentId = 3},
							new(){Id = 12, Title="Gebelik takibi ve doğum hizmetleri", DepartmentId = 3},
							new(){Id = 13, Title="Jinekolojik kanserlerin tanısı ve tedavisi", DepartmentId = 3},
							new(){Id = 14, Title="Nörolojik muayene ve sağlık taramaları", DepartmentId = 4},
							new(){Id = 15, Title="Görüntüleme yöntemleri (MR, BT taramaları) ve sinir ileti testleri", DepartmentId = 4},
							new(){Id = 16, Title="Baş ağrısı ve migren tedavisi", DepartmentId = 4},
							new(){Id = 17, Title="İnme tedavisi ve rehabilitasyonu", DepartmentId = 4},
							new(){Id = 18, Title="Epilepsi tanısı ve tedavisi", DepartmentId = 4},
							new(){Id = 19, Title="Uyku bozuklukları (uyku apnesi, uyku yürüme) tedavisi", DepartmentId = 4},
				}
				);
			modelBuilder.Entity<Page>().HasData(
				new List<Page>
				{
					new Page()
					{
						Id = 1,
						Content = "Hoş Geldiniz!\r\n\r\nBiz, XYZ Hastanesi olarak, topluma en iyi sağlık hizmetini sunmak ve hastalarımızın ihtiyaçlarını en üst düzeyde karşılamak için buradayız. Misyonumuz, sağlık ve refahınızı korumak ve geliştirmek için sizlere uzmanlık, deneyim ve empati sunmaktır.\r\n\r\nXYZ Hastanesi, kaliteli sağlık hizmetleri sunmak adına sürekli olarak kendini yenileyen ve gelişen bir sağlık kuruluşudur. Sağlık sektöründeki en son teknolojileri takip ediyor ve en iyilerini sizlere sunmak için çaba sarf ediyoruz. Deneyimli ve alanında uzman bir sağlık ekibiyle birlikte çalışıyoruz, böylece sizlere en uygun tedavi yöntemlerini ve çözümlerini sunabiliyoruz.\r\n\r\nHastalarımızın sağlığı ve güvenliği bizim için en önemli önceliktir. Tüm süreçlerimizde yüksek standartlara uygunluğu sağlayarak, güvenli ve hijyenik bir ortam sunmaktayız. Hastalarımızın rahatlığını ve huzurunu sağlamak için tesislerimizi modernize ediyor ve konforlu bir ortam yaratıyoruz.\r\n\r\nXYZ Hastanesi olarak, multidisipliner bir yaklaşım benimsemekteyiz. Çeşitli tıbbi alanlarda uzmanlaşmış doktorlarımız, hemşirelerimiz ve diğer sağlık çalışanlarımız bir araya gelerek, sizlere kapsamlı ve bütüncül bir sağlık hizmeti sunmaktadır. Tedavi süreciniz boyunca size destek olmak ve sorularınızı yanıtlamak için her zaman buradayız.\r\n\r\nSizleri sağlık yolculuğunuzda yanınızda olmaktan dolayı onur duyarız. Size en kaliteli sağlık hizmetini sunmak ve sağlığınızı desteklemek için elimizden geleni yapacağımızı taahhüt ediyoruz.\r\n\r\nXYZ Hastanesi olarak, sizlere hızlı, etkili ve insana odaklı sağlık hizmetleri sunmak için sabırsızlanıyoruz. Size özel sağlık çözümleri sunmak ve sizleri sağlıklı ve mutlu bir yaşama kavuşturmak için buradayız.\r\n\r\nSağlık yolculuğunuzda sizlere yardımcı olmak için bize güvenebilirsiniz!",
						Title = "Hakkımızda"
					},
					new Page()
					{
						Id = 2,
						Content = "Geniş Hizmet Yelpazemizle Yanınızdayız\r\n\r\nXYZ Hastanesi olarak, hastalarımıza kapsamlı ve kaliteli sağlık hizmetleri sunmaktan gurur duyuyoruz. Deneyimli doktorlarımız, uzman hemşirelerimiz ve sağlık çalışanlarımızla birlikte, çeşitli tıbbi alanlarda hizmet veriyor ve hastalarımızın ihtiyaçlarını en üst düzeyde karşılıyoruz.\r\n\r\nHizmetlerimiz şunları içermektedir:\r\n\r\nPoliklinik Hizmetleri: Hastalarımızın tanı ve tedavi süreçlerinde en iyi hizmeti sunmak için çeşitli polikliniklerde faaliyet gösteriyoruz. Genel cerrahi, iç hastalıkları, pediatri, dermatoloji, ortopedi, kadın hastalıkları ve doğum gibi birçok farklı poliklinik hizmeti sunmaktayız.\r\n\r\nAcil Servis: Acil durumlarda hızlı ve etkili müdahale sağlamak için 7/24 açık olan acil servisimiz mevcuttur. Deneyimli acil tıp uzmanlarımız ve tıbbi personelimiz, acil tıbbi durumlarınızda hızlı bir şekilde size yardımcı olmak için hazır beklemektedir.\r\n\r\nCerrahi Müdahaleler: Alanında uzman cerrahlarımızla birlikte, çeşitli cerrahi prosedürler sunmaktayız. Laparoskopik cerrahi, göğüs cerrahisi, ortopedik cerrahi, nörolojik cerrahi ve plastik cerrahi gibi alanlarda uzmanlaşmış ekiplerimiz, ameliyatlarınızı güvenli ve etkili bir şekilde gerçekleştirmektedir.\r\n\r\nGörüntüleme ve Tanı: Gelişmiş görüntüleme teknolojileriyle donatılmış olan tesisimizde, kesin ve doğru tanı koymak amacıyla bir dizi görüntüleme hizmeti sunmaktayız. MR, BT, ultrason ve röntgen gibi tanısal görüntüleme yöntemleriyle hastalarımızın sağlık durumunu değerlendirmekteyiz.\r\n\r\nLaboratuvar Hizmetleri: Hızlı ve güvenilir laboratuvar sonuçları sağlamak için kapsamlı laboratuvar hizmetleri sunmaktayız. Kan testleri, idrar analizleri, patoloji incelemeleri ve genetik testler gibi birçok farklı laboratuvar testini gerçekleştiriyoruz.\r\n\r\nRehabilitasyon ve Fizik Tedavi: Yaralanmaların iyileştirilmesi, fiziksel fonksiyonların geri kazanılması ve yaşam kalitesinin artırılması için fizik tedavi ve rehabilitasyon hizmetleri sunmaktayız. Fizyoterapistlerimiz, uzmanlıklarını kullanarak hastalarımıza bireysel tedavi planları sağlamaktadır.\r\n\r\nPsikiyatri ve Psikoloji Danışmanlığı: Zihinsel sağlık ve refahınızı desteklemek için uzman psikiyatristler ve psikologlarımızla birlikte çalışıyoruz. Depresyon, anksiyete, stres gibi konularda danışmanlık hizmetleri sunuyor ve hastalarımızın sağlıklı bir zihinsel dengeye ulaşmasına yardımcı oluyoruz.\r\n\r\nXYZ Hastanesi olarak, hastalarımızın ihtiyaçlarını anlamak ve en uygun tedavi yöntemlerini sunmak için elimizden gelenin en iyisini yapmaktayız. Sağlık yolculuğunuzda sizlere destek olmak ve sağlığınızı en üst düzeyde tutmak için buradayız.\r\n\r\n",
						Title = "Hizmetlerimiz"
					}
				});

			modelBuilder.Entity<User>()
				.HasMany(u => u.PostComments)
				.WithOne(pc => pc.User)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
